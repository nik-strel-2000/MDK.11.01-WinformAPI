﻿using ConnectApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace ConnectApi
{
    public partial class PositionForm : Form
    {
        public PositionForm()
        {
            InitializeComponent();
        }

        //Возврат Слиента для работы запроса
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
        //Загрузка Таблицы
        public void LoadDataGrid()
        {
            var posts = RequstPost();
            dataGridViewPosition.DataSource = posts;
        }

        //Загрузка Списка
        public void LoadList()
        {
            var posts = RequstPost();
            List<string> posts1 = new List<string>();
            foreach(Post post in posts)
            {
                posts1.Add($"{post.Name}");
            }
            listPosition.Items.AddRange(posts1.ToArray());
        }
        //Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            LoadList();
        }

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



    }
}
