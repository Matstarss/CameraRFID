using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CameraRFID
{
    class Diary
    {
        public Diary()
        {

        }

        public async Task updateDiary(string job, string cardNumber, double measureWormWeight, double measureCO2, 
            double measureNH3, double measureTEMP, double measureHUMID,string selectInstarName)
        {
            try
            {
                string requestUrl = "https://ifactoryfarm.farminsf.com/back/createDiary/{job}/{cardNumber}"
                            .Replace("{job}", job)
                            .Replace("{cardNumber}", cardNumber);

                Console.WriteLine(requestUrl);

                JObject bodyMessage = new JObject();

                    JArray tags = new JArray();
                    JArray diaryItmes = new JArray();

                    JObject tagCO2 = new JObject();
                    JObject tagNH3 = new JObject();
                    JObject tagHUMID = new JObject();
                    JObject tagTEMP = new JObject();

                    JObject instar = new JObject();
                    JObject wormWeight = new JObject();

                    tagCO2.Add("name", "CO2");
                    tagCO2.Add("value", measureCO2);
                    tags.Add(tagCO2);

                    tagNH3.Add("name", "NH3");
                    tagNH3.Add("value", measureNH3);
                    tags.Add(tagNH3);

                    tagHUMID.Add("name", "습도");
                    tagHUMID.Add("value", measureHUMID);
                    tags.Add(tagHUMID);

                    tagTEMP.Add("name", "온도");
                    tagTEMP.Add("value", measureTEMP);
                    tags.Add(tagTEMP);

                    //생육단계
                    instar.Add("name", "instar");
                    instar.Add("value", selectInstarName);
                    diaryItmes.Add(instar);

                   //개체무게
                    wormWeight.Add("name", "wormWeight");
                    wormWeight.Add("value", measureWormWeight);
                    diaryItmes.Add(wormWeight);


                    bodyMessage.Add("diaryItems", diaryItmes);
                    bodyMessage.Add("tags", tags);


                var client = new HttpClient();
                var response = await sendHttpRequestAsync(client, requestUrl, bodyMessage);

                // 응답 데이터 가져오기
                var responseJson = await response.Content.ReadAsStringAsync();

                // 응답 데이터 역직렬화
                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseJson);

                JObject parseJSON = JObject.Parse(responseJson);

                var id = (int)parseJSON["diaryId"];

                //이미지 파일 업로드
                await uploadImageAsync(id);

             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        public async Task<HttpResponseMessage> sendHttpRequestAsync(HttpClient client, string requestUrl, JObject bodyMessage)
        {
            try
            {
                client.DefaultRequestHeaders.ExpectContinue = false; // <-- Make sure it is false.
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpContent = new StringContent(bodyMessage.ToString(Formatting.None), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUrl, httpContent);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                return null;
            }
        }

        public async Task uploadImageAsync(int diaryId)
        {
            try
            {
                var client = new HttpClient();

                using (var form = new MultipartFormDataContent())
                {
                    // Get the path of the local application data folder
                    string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                    // Define the snapshot directory
                    string snapshotDirectory = Path.Combine(localAppData, "CAMERA_RFID", "Snapshot");

                    // Define the full file path
                    string imagePath = Path.Combine(snapshotDirectory, "Snapshot.bmp");

                    if (File.Exists(imagePath))
                    {
                        var imageContent = new ByteArrayContent(File.ReadAllBytes(imagePath));
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        form.Add(imageContent, "image", Path.GetFileName(imagePath));

                        // API URL 생성
                        string apiUrlWithParams = "https://ifactoryfarm.farminsf.com/back/ifactory/api/file/uploadfile/{uploadPath}/{id}"
                            .Replace("{uploadPath}", "diary")
                            .Replace("{id}", diaryId.ToString());

                        // API 호출
                        var uploadResponse = await client.PostAsync(apiUrlWithParams, form);
                        if (uploadResponse.IsSuccessStatusCode)
                        {
                            var uploadResult = await uploadResponse.Content.ReadAsStringAsync();
                            Console.WriteLine("image_upload_resut: " + uploadResult);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + uploadResponse.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}
