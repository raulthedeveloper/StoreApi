using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using StoreApi.Models;

namespace StoreApi.DAL
{
    public class CRUD
    {

     

        string ConnectionString = @"Data Source=IVORY\SQLEXPRESS; Integrated Security=true; Initial Catalog=Ecommerce";

        DataTable dtbl = new DataTable();

      

        public  List<ProductsModel> GetAllProducts(){


           

            List<ProductsModel> productsList = new List<ProductsModel>();
            // queries Database and return all models
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
               SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Products",sqlCon);

                sqlDa.Fill(dtbl);

                if(dtbl.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in dtbl.Rows)
                    {
                        

                        productsList.Add(new ProductsModel() {
                        Id = int.Parse(row["id"].ToString()),
                        catId = int.Parse(row["catId"].ToString()),
                        name = row["name"].ToString(),
                        description = row["description"].ToString(),
                        image = row["image"].ToString(),
                        price = int.Parse(row["price"].ToString())
                    });

                       

                    }
                }
                else
                {
                    productsList.Add(new ProductsModel()
                    {
                        name = "No Data"
                    });
                }
            }
            return productsList ;

          }

        public  List<CategoriesModel> GetAllCategories()
        {

            List<CategoriesModel> categoriesList = new List<CategoriesModel>();

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Category", sqlCon);


                sqlDa.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {

                    foreach (DataRow row in dtbl.Rows)
                    {
                        
                        categoriesList.Add(new CategoriesModel()
                        {
                             id = int.Parse(row["id"].ToString()),
                             name = row["name"].ToString(),
                             description = row["description"].ToString(),
                             image = row["image"].ToString(),
                         });



                    }
                }
                else
                {
                    categoriesList.Add(new CategoriesModel()
                    {
                        name = "No Data"
                       
                    });
                }
            }


            return categoriesList;

        }



        public void InsertProduct(ProductsModel product)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO products (catId,name,description,image,price) VALUES ({product.catId},'{product.name}', '{product.description}','{product.image}',{product.price});", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void InsertCategory(CategoriesModel categories)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO category (name,description,image) VALUES ('{categories.name}', '{categories.description}','{categories.image}');", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void UpdateProduct(int id, ProductsModel product)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE products SET catId = '{product.catId}', name = '{product.name}', description = '{product.description}', image = '{product.image}', price = {product.price} WHERE id = {id};", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCategory(int id,CategoriesModel category)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE category SET  name = '{category.name}', description = '{category.description}', image = '{category.image}' WHERE id = {id};", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM products WHERE id = {id};", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM category WHERE id = {id};", sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


}
