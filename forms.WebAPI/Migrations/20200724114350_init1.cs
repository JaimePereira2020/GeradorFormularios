﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace forms.WebAPI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    CreatorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    institution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creator", x => x.CreatorID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    institution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    FormID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    version = table.Column<string>(nullable: true),
                    theme = table.Column<string>(nullable: true),
                    CreatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.FormID);
                    table.ForeignKey(
                        name: "FK_Form_Creator_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Creator",
                        principalColumn: "CreatorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matrix",
                columns: table => new
                {
                    MatrixID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descriptionMatrix = table.Column<string>(nullable: true),
                    possibilityAnswerMatrix = table.Column<string>(nullable: true),
                    positionMatrix = table.Column<int>(nullable: false),
                    FormID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrix", x => x.MatrixID);
                    table.ForeignKey(
                        name: "FK_Matrix_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserForm",
                columns: table => new
                {
                    UserFormID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    FormID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForm", x => x.UserFormID);
                    table.ForeignKey(
                        name: "FK_UserForm_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserForm_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    questionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descriptionValueQuetion = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    label = table.Column<string>(nullable: true),
                    help = table.Column<string>(nullable: true),
                    placeHolder = table.Column<string>(nullable: true),
                    className = table.Column<string>(nullable: true),
                    subType = table.Column<string>(nullable: true),
                    regex = table.Column<string>(nullable: true),
                    erroText = table.Column<string>(nullable: true),
                    condiction = table.Column<string>(nullable: true),
                    flagDependency = table.Column<bool>(nullable: false),
                    quetionDependency = table.Column<string>(nullable: true),
                    answerDependency = table.Column<string>(nullable: true),
                    positionQuetion = table.Column<string>(nullable: true),
                    FormID = table.Column<int>(nullable: true),
                    MatrixID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.questionID);
                    table.ForeignKey(
                        name: "FK_Question_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Matrix_MatrixID",
                        column: x => x.MatrixID,
                        principalTable: "Matrix",
                        principalColumn: "MatrixID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PossibilityAnswer",
                columns: table => new
                {
                    PossibilityAnswerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descriptionValuePossibilityAnswer = table.Column<string>(nullable: true),
                    MatrixID = table.Column<int>(nullable: true),
                    FormID = table.Column<int>(nullable: true),
                    questionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibilityAnswer", x => x.PossibilityAnswerID);
                    table.ForeignKey(
                        name: "FK_PossibilityAnswer_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PossibilityAnswer_Matrix_MatrixID",
                        column: x => x.MatrixID,
                        principalTable: "Matrix",
                        principalColumn: "MatrixID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PossibilityAnswer_Question_questionID",
                        column: x => x.questionID,
                        principalTable: "Question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descriptionValueAnswer = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    FormID = table.Column<int>(nullable: true),
                    PossibilityAnswerID = table.Column<int>(nullable: true),
                    questionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_PossibilityAnswer_PossibilityAnswerID",
                        column: x => x.PossibilityAnswerID,
                        principalTable: "PossibilityAnswer",
                        principalColumn: "PossibilityAnswerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answer_Question_questionID",
                        column: x => x.questionID,
                        principalTable: "Question",
                        principalColumn: "questionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_FormID",
                table: "Answer",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_PossibilityAnswerID",
                table: "Answer",
                column: "PossibilityAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserID",
                table: "Answer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_questionID",
                table: "Answer",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_Form_CreatorID",
                table: "Form",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Matrix_FormID",
                table: "Matrix",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_PossibilityAnswer_FormID",
                table: "PossibilityAnswer",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_PossibilityAnswer_MatrixID",
                table: "PossibilityAnswer",
                column: "MatrixID");

            migrationBuilder.CreateIndex(
                name: "IX_PossibilityAnswer_questionID",
                table: "PossibilityAnswer",
                column: "questionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_FormID",
                table: "Question",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_MatrixID",
                table: "Question",
                column: "MatrixID");

            migrationBuilder.CreateIndex(
                name: "IX_UserForm_FormID",
                table: "UserForm",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserForm_UserID",
                table: "UserForm",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "UserForm");

            migrationBuilder.DropTable(
                name: "PossibilityAnswer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Matrix");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Creator");
        }
    }
}
