﻿using SQLite;
using SQLiteDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteDemo
{
    //[Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement] //Column("RecipeId")
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;
        public MainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing() //metodo que se invoca cuando aparece la pagina 
        {
            await _connection.CreateTableAsync<Recipe>(); //creacion de tabla

            var recipes = await _connection.Table<Recipe>().ToListAsync();

            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing(); 
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " UPDATED";

            await _connection.UpdateAsync(recipe);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}
