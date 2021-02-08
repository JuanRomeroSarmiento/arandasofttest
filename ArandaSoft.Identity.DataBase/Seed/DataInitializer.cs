using ArandaSoft.Identity.Contracts.Security;
using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Text;

namespace ArandaSoft.Identity.DataBase.Seed
{
    public static class DataInitializer
    {
        private const string Id = "Id";
        private const string BusinessSchema = "bnl";
        private const string adminstratorPassword = "123";
        private static byte[] administratorSalt = Cryptographic.GenerateSalt();


        public static void Seed(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.InsertData(
            nameof(Rol),
            new[] { Id, nameof(User.Name) },                        
            new object[,]
            {
                { 1, "Guest" },
                { 2, "Assistant"},
                { 3, "Editor" },
                { 4, "Administrator" },
            },
            BusinessSchema
            );

            migrationBuilder.InsertData(
            nameof(Permission),
            new[] { Id, nameof(Permission.Name) },
            new object[,]
            {
                { 1, "Basic" },
                { 2, "Select"},
                { 3, "Edit" },
                { 4, "Create" },
                { 5, "Delete"}
            },
            BusinessSchema
            );

            migrationBuilder.InsertData(
                nameof(RolPermission),
                new[]
                {
                    nameof(RolPermission.RolId),
                    nameof(RolPermission.PermissionId)
                },
                new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },                    
                },
                BusinessSchema
                );

            migrationBuilder.InsertData(
            nameof(User),
            new[] { Id, nameof(User.Name), 
                        nameof(User.PasswordHash),
                        nameof(User.Salt),
                        nameof(User.FullName),                                                  
                        nameof(User.Email),                                                
                        nameof(User.RolId) },
            new object[,]
            {
                { 
                    Guid.NewGuid(), 
                    "Administrator",
                    Cryptographic.HashPasswordWithSalt(
                        Encoding.UTF8.GetBytes(adminstratorPassword),administratorSalt), 
                    administratorSalt, 
                    "Administrator", 
                    "administrator@arandasoft.com", 
                    4 
                }
            },
            BusinessSchema
            );
        }        
    }
}
