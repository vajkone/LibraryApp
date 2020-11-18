using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp_WebAPI.Migrations
{
    public partial class fixFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBook_Books_BookId",
                table: "LibraryBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBook_LibraryBook_InventoryNumber",
                table: "LoanBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBook_Members_MemberId",
                table: "LoanBook");

            migrationBuilder.RenameColumn(
                name: "returnDate",
                table: "LoanBook",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "InventoryNumber",
                table: "LoanBook",
                newName: "LB_InventoryNumber");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "LoanBook",
                newName: "LB_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanBook_InventoryNumber",
                table: "LoanBook",
                newName: "IX_LoanBook_LB_InventoryNumber");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "LibraryBook",
                newName: "LB_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBook_BookId",
                table: "LibraryBook",
                newName: "IX_LibraryBook_LB_BookId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookAuthor",
                newName: "BA_BookId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "BookAuthor",
                newName: "BA_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BA_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_BA_AuthorId",
                table: "BookAuthor",
                column: "BA_AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BA_BookId",
                table: "BookAuthor",
                column: "BA_BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBook_Books_LB_BookId",
                table: "LibraryBook",
                column: "LB_BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBook_LibraryBook_LB_InventoryNumber",
                table: "LoanBook",
                column: "LB_InventoryNumber",
                principalTable: "LibraryBook",
                principalColumn: "InventoryNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBook_Members_LB_MemberId",
                table: "LoanBook",
                column: "LB_MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_BA_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BA_BookId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBook_Books_LB_BookId",
                table: "LibraryBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBook_LibraryBook_LB_InventoryNumber",
                table: "LoanBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBook_Members_LB_MemberId",
                table: "LoanBook");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "LoanBook",
                newName: "returnDate");

            migrationBuilder.RenameColumn(
                name: "LB_InventoryNumber",
                table: "LoanBook",
                newName: "InventoryNumber");

            migrationBuilder.RenameColumn(
                name: "LB_MemberId",
                table: "LoanBook",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanBook_LB_InventoryNumber",
                table: "LoanBook",
                newName: "IX_LoanBook_InventoryNumber");

            migrationBuilder.RenameColumn(
                name: "LB_BookId",
                table: "LibraryBook",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBook_LB_BookId",
                table: "LibraryBook",
                newName: "IX_LibraryBook_BookId");

            migrationBuilder.RenameColumn(
                name: "BA_BookId",
                table: "BookAuthor",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "BA_AuthorId",
                table: "BookAuthor",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BA_BookId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBook_Books_BookId",
                table: "LibraryBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBook_LibraryBook_InventoryNumber",
                table: "LoanBook",
                column: "InventoryNumber",
                principalTable: "LibraryBook",
                principalColumn: "InventoryNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBook_Members_MemberId",
                table: "LoanBook",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
