# MDK.11.01-WinformAPI
Создание winform приложения для МДК 11.01
Методы взаимодействия
        
        //МЕТОДЫ ДЛЯ ОБРАЩЕНИЯ 
        //POST-----------------------------------
        public void UserPost(Post post)
        {
            HttpClient client = RequstClient();
            //В моделе не должно быть заполнено поле id
            string jsonString = JsonConvert.SerializeObject(post);
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync("api/Posts", httpContent).GetAwaiter().GetResult();
        }

        //PUT------------------------------------
        public void UpdateUser(Post post)
        {
            HttpClient client = RequstClient();
            //В моделе ДОЛЖНО быть заполнено поле id
            string jsonString = JsonConvert.SerializeObject(post);
            HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PutAsync($"api/Posts/{post.IdPosition}", httpContent).GetAwaiter().GetResult();
            string message;
            if (responseMessage.StatusCode.ToString() == "NoContent")
            {
                message = "Успешно";
            }
            else
            {
                message = "Ошибка";
            }
            MessageBox.Show(message);
        }
        //DELETE---------------------------------
        public void DeletePost(int id)
        {
            HttpClient client = RequstClient();
            HttpResponseMessage response = client.DeleteAsync($@"api/Post/{id}").Result;
        }
