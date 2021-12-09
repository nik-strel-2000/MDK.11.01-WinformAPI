# MDK.11.01-WinformAPI
Создание winform приложения для МДК 11.01

     //Возврат Клиента для работы запроса
        public HttpClient RequstClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:35268/");
            return client;
        }
        //Возврат Должностей
        public IEnumerable<Post> RequstPost()
        {
            HttpClient client = RequstClient();
            HttpResponseMessage response = client.GetAsync("/api/Posts").Result;
            var posts = response.Content.ReadAsAsync<IEnumerable<Post>>().Result;
            return posts;
        }
