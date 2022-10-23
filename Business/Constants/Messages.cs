using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added!";
        public static string ProductDeleted = "Product Deleted!";
        public static string ProductUpdated = "Product Updated";
        public static string ProductsListed = "Products Listed!";
        public static string ProductInvalid = "Product Invalid!";
        public static string ImageSaved="Image Saved!";
        public static string ImageDeleted="Image Deleted!";
        public static string ImageUpdated="Image Updated!";
        public static string ImagesListed="Images Listed!";
        public static string UserNotFound="User Not Found!";
        public static string WrongPassword="Wrong Password!";
        public static string SuccessLogin="Log in is Successful";
        public static string UserAlreadyExists="User already exists!";
        public static string UserRegistered="User Registered!";
        public static string AccessTokenCreated = "Access Token Created!";
        public static string AuthorizationDenied="Authorization Denied!";
    }
}
