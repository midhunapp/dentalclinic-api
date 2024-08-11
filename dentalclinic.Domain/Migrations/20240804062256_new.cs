using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dentalclinic.Domain.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(type: "varchar(200)", nullable: false),
                    NationalityCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "Int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserRegNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "Int", nullable: false),
                    UserTypeId = table.Column<int>(type: "Int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 1, 1, "AF", "AFGHANISTAN" },
                    { 2, 1, "AL", "ALBANIA" },
                    { 3, 1, "DZ", "ALGERIA" },
                    { 4, 1, "AS", "AMERICAN SAMOA" },
                    { 5, 1, "AD", "ANDORRA" },
                    { 6, 1, "AO", "ANGOLA" },
                    { 7, 1, "AI", "ANGUILLA" },
                    { 8, 1, "AQ", "ANTARCTICA" },
                    { 9, 1, "AG", "ANTIGUA AND BARBUDA" },
                    { 10, 1, "AR", "ARGENTINA" },
                    { 11, 1, "AM", "ARMENIA" },
                    { 12, 1, "AW", "ARUBA" },
                    { 13, 1, "AU", "AUSTRALIA" },
                    { 14, 1, "AT", "AUSTRIA" },
                    { 15, 1, "AZ", "AZERBAIJAN" },
                    { 16, 1, "BS", "BAHAMAS" },
                    { 17, 1, "BH", "BAHRAIN" },
                    { 18, 1, "BD", "BANGLADESH" },
                    { 19, 1, "BB", "BARBADOS" },
                    { 20, 1, "BY", "BELARUS" },
                    { 21, 1, "BE", "BELGIUM" },
                    { 22, 1, "BZ", "BELIZE" },
                    { 23, 1, "BJ", "BENIN" },
                    { 24, 1, "BM", "BERMUDA" },
                    { 25, 1, "BT", "BHUTAN" },
                    { 26, 1, "BO", "BOLIVIA" },
                    { 27, 1, "BA", "BOSNIA AND HERZEGOVINA" },
                    { 28, 1, "BW", "BOTSWANA" },
                    { 29, 1, "BV", "BOUVET ISLAND" },
                    { 30, 1, "BR", "BRAZIL" },
                    { 31, 1, "IO", "BRITISH INDIAN OCEAN TERRITORY" },
                    { 32, 1, "BN", "BRUNEI DARUSSALAM" },
                    { 33, 1, "BG", "BULGARIA" },
                    { 34, 1, "BF", "BURKINA FASO" },
                    { 35, 1, "BI", "BURUNDI" },
                    { 36, 1, "KH", "CAMBODIA" },
                    { 37, 1, "CM", "CAMEROON" },
                    { 38, 1, "CA", "CANADA" },
                    { 39, 1, "CV", "CAPE VERDE" },
                    { 40, 1, "KY", "CAYMAN ISLANDS" },
                    { 41, 1, "CF", "CENTRAL AFRICAN REPUBLIC" },
                    { 42, 1, "TD", "CHAD" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 43, 1, "CL", "CHILE" },
                    { 44, 1, "CN", "CHINA" },
                    { 45, 1, "CX", "CHRISTMAS ISLAND" },
                    { 46, 1, "CC", "COCOS new Nationality{ NationalityId=KEELING) ISLANDS" },
                    { 47, 1, "CO", "COLOMBIA" },
                    { 48, 1, "KM", "COMOROS" },
                    { 49, 1, "CG", "CONGO" },
                    { 50, 1, "CD", "CONGO, THE DEMOCRATIC REPUBLIC OF THE" },
                    { 51, 1, "CK", "COOK ISLANDS" },
                    { 52, 1, "CR", "COSTA RICA" },
                    { 53, 1, "CI", "COTE D'IVOIRE" },
                    { 54, 1, "HR", "CROATIA" },
                    { 55, 1, "CU", "CUBA" },
                    { 56, 1, "CY", "CYPRUS" },
                    { 57, 1, "CZ", "CZECH REPUBLIC" },
                    { 58, 1, "DK", "DENMARK" },
                    { 59, 1, "DJ", "DJIBOUTI" },
                    { 60, 1, "DM", "DOMINICA" },
                    { 61, 1, "DO", "DOMINICAN REPUBLIC" },
                    { 62, 1, "EC", "ECUADOR" },
                    { 63, 1, "EG", "EGYPT" },
                    { 64, 1, "SV", "EL SALVADOR" },
                    { 65, 1, "GQ", "EQUATORIAL GUINEA" },
                    { 66, 1, "ER", "ERITREA" },
                    { 67, 1, "EE", "ESTONIA" },
                    { 68, 1, "ET", "ETHIOPIA" },
                    { 69, 1, "FK", "FALKLAND ISLANDS new Nationality{ NationalityId=MALVINAS)" },
                    { 70, 1, "FO", "FAROE ISLANDS" },
                    { 71, 1, "FJ", "FIJI" },
                    { 72, 1, "FI", "FINLAND" },
                    { 73, 1, "FR", "FRANCE" },
                    { 74, 1, "GF", "FRENCH GUIANA" },
                    { 75, 1, "PF", "FRENCH POLYNESIA" },
                    { 76, 1, "TF", "FRENCH SOUTHERN TERRITORIES" },
                    { 77, 1, "GA", "GABON" },
                    { 78, 1, "GM", "GAMBIA" },
                    { 79, 1, "GE", "GEORGIA" },
                    { 80, 1, "DE", "GERMANY" },
                    { 81, 1, "GH", "GHANA" },
                    { 82, 1, "GI", "GIBRALTAR" },
                    { 83, 1, "GR", "GREECE" },
                    { 84, 1, "GL", "GREENLAND" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 85, 1, "GD", "GRENADA" },
                    { 86, 1, "GP", "GUADELOUPE" },
                    { 87, 1, "GU", "GUAM" },
                    { 88, 1, "GT", "GUATEMALA" },
                    { 89, 1, "GN", "GUINEA" },
                    { 90, 1, "GW", "GUINEA-BISSAU" },
                    { 91, 1, "GY", "GUYANA" },
                    { 92, 1, "HT", "HAITI" },
                    { 93, 1, "HM", "HEARD ISLAND AND MCDONALD ISLANDS" },
                    { 94, 1, "VA", "HOLY SEE new Nationality{ NationalityId=VATICAN CITY STATE)" },
                    { 95, 1, "HN", "HONDURAS" },
                    { 96, 1, "HK", "HONG KONG" },
                    { 97, 1, "HU", "HUNGARY" },
                    { 98, 1, "IS", "ICELAND" },
                    { 99, 1, "IN", "INDIA" },
                    { 100, 1, "ID", "INDONESIA" },
                    { 101, 1, "IR", "IRAN, ISLAMIC REPUBLIC OF" },
                    { 102, 1, "IQ", "IRAQ" },
                    { 103, 1, "IE", "IRELAND" },
                    { 104, 1, "IL", "ISRAEL" },
                    { 105, 1, "IT", "ITALY" },
                    { 106, 1, "JM", "JAMAICA" },
                    { 107, 1, "JP", "JAPAN" },
                    { 108, 1, "JO", "JORDAN" },
                    { 109, 1, "KZ", "KAZAKHSTAN" },
                    { 110, 1, "KE", "KENYA" },
                    { 111, 1, "KI", "KIRIBATI" },
                    { 112, 1, "KP", "KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF" },
                    { 113, 1, "KR", "KOREA, REPUBLIC OF" },
                    { 114, 1, "KW", "KUWAIT" },
                    { 115, 1, "KG", "KYRGYZSTAN" },
                    { 116, 1, "LA", "LAO PEOPLE'S DEMOCRATIC REPUBLIC" },
                    { 117, 1, "LV", "LATVIA" },
                    { 118, 1, "LB", "LEBANON" },
                    { 119, 1, "LS", "LESOTHO" },
                    { 120, 1, "LR", "LIBERIA" },
                    { 121, 1, "LY", "LIBYAN ARAB JAMAHIRIYA" },
                    { 122, 1, "LI", "LIECHTENSTEIN" },
                    { 123, 1, "LT", "LITHUANIA" },
                    { 124, 1, "LU", "LUXEMBOURG" },
                    { 125, 1, "MO", "MACAO" },
                    { 126, 1, "MK", "MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 127, 1, "MG", "MADAGASCAR" },
                    { 128, 1, "MW", "MALAWI" },
                    { 129, 1, "MY", "MALAYSIA" },
                    { 130, 1, "MV", "MALDIVES" },
                    { 131, 1, "ML", "MALI" },
                    { 132, 1, "MT", "MALTA" },
                    { 133, 1, "MH", "MARSHALL ISLANDS" },
                    { 134, 1, "MQ", "MARTINIQUE" },
                    { 135, 1, "MR", "MAURITANIA" },
                    { 136, 1, "MU", "MAURITIUS" },
                    { 137, 1, "YT", "MAYOTTE" },
                    { 138, 1, "MX", "MEXICO" },
                    { 139, 1, "FM", "MICRONESIA, FEDERATED STATES OF" },
                    { 140, 1, "MD", "MOLDOVA, REPUBLIC OF" },
                    { 141, 1, "MC", "MONACO" },
                    { 142, 1, "MN", "MONGOLIA" },
                    { 143, 1, "MS", "MONTSERRAT" },
                    { 144, 1, "MA", "MOROCCO" },
                    { 145, 1, "MZ", "MOZAMBIQUE" },
                    { 146, 1, "MM", "MYANMAR" },
                    { 147, 1, "NA", "NAMIBIA" },
                    { 148, 1, "NR", "NAURU" },
                    { 149, 1, "NP", "NEPAL" },
                    { 150, 1, "NL", "NETHERLANDS" },
                    { 151, 1, "AN", "NETHERLANDS ANTILLES" },
                    { 152, 1, "NC", "NEW CALEDONIA" },
                    { 153, 1, "NZ", "NEW ZEALAND" },
                    { 154, 1, "NI", "NICARAGUA" },
                    { 155, 1, "NE", "NIGER" },
                    { 156, 1, "NG", "NIGERIA" },
                    { 157, 1, "NU", "NIUE" },
                    { 158, 1, "NF", "NORFOLK ISLAND" },
                    { 159, 1, "MP", "NORTHERN MARIANA ISLANDS" },
                    { 160, 1, "NO", "NORWAY" },
                    { 161, 1, "OM", "OMAN" },
                    { 162, 1, "PK", "PAKISTAN" },
                    { 163, 1, "PW", "PALAU" },
                    { 164, 1, "PS", "PALESTINIAN TERRITORY, OCCUPIED" },
                    { 165, 1, "PA", "PANAMA" },
                    { 166, 1, "PG", "PAPUA NEW GUINEA" },
                    { 167, 1, "PY", "PARAGUAY" },
                    { 168, 1, "PE", "PERU" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 169, 1, "PH", "PHILIPPINES" },
                    { 170, 1, "PN", "PITCAIRN" },
                    { 171, 1, "PL", "POLAND" },
                    { 172, 1, "PT", "PORTUGAL" },
                    { 173, 1, "PR", "PUERTO RICO" },
                    { 174, 1, "QA", "QATAR" },
                    { 175, 1, "RE", "REUNION" },
                    { 176, 1, "RO", "ROMANIA" },
                    { 177, 1, "RU", "RUSSIAN FEDERATION" },
                    { 178, 1, "RW", "RWANDA" },
                    { 179, 1, "SH", "SAINT HELENA" },
                    { 180, 1, "KN", "SAINT KITTS AND NEVIS" },
                    { 181, 1, "LC", "SAINT LUCIA" },
                    { 182, 1, "PM", "SAINT PIERRE AND MIQUELON" },
                    { 183, 1, "VC", "SAINT VINCENT AND THE GRENADINES" },
                    { 184, 1, "WS", "SAMOA" },
                    { 185, 1, "SM", "SAN MARINO" },
                    { 186, 1, "ST", "SAO TOME AND PRINCIPE" },
                    { 187, 1, "SA", "SAUDI ARABIA" },
                    { 188, 1, "SN", "SENEGAL" },
                    { 189, 1, "CS", "SERBIA AND MONTENEGRO" },
                    { 190, 1, "SC", "SEYCHELLES" },
                    { 191, 1, "SL", "SIERRA LEONE" },
                    { 192, 1, "SG", "SINGAPORE" },
                    { 193, 1, "SK", "SLOVAKIA" },
                    { 194, 1, "SI", "SLOVENIA" },
                    { 195, 1, "SB", "SOLOMON ISLANDS" },
                    { 196, 1, "SO", "SOMALIA" },
                    { 197, 1, "ZA", "SOUTH AFRICA" },
                    { 198, 1, "GS", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS" },
                    { 199, 1, "ES", "SPAIN" },
                    { 200, 1, "LK", "SRI LANKA" },
                    { 201, 1, "SD", "SUDAN" },
                    { 202, 1, "SR", "SURINAME" },
                    { 203, 1, "SJ", "SVALBARD AND JAN MAYEN" },
                    { 204, 1, "SZ", "SWAZILAND" },
                    { 205, 1, "SE", "SWEDEN" },
                    { 206, 1, "CH", "SWITZERLAND" },
                    { 207, 1, "SY", "SYRIAN ARAB REPUBLIC" },
                    { 208, 1, "TW", "TAIWAN, PROVINCE OF CHINA" },
                    { 209, 1, "TJ", "TAJIKISTAN" },
                    { 210, 1, "TZ", "TANZANIA, UNITED REPUBLIC OF" }
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "IsActive", "NationalityCode", "NationalityName" },
                values: new object[,]
                {
                    { 211, 1, "TH", "THAILAND" },
                    { 212, 1, "TL", "TIMOR-LESTE" },
                    { 213, 1, "TG", "TOGO" },
                    { 214, 1, "TK", "TOKELAU" },
                    { 215, 1, "TO", "TONGA" },
                    { 216, 1, "TT", "TRINIDAD AND TOBAGO" },
                    { 217, 1, "TN", "TUNISIA" },
                    { 218, 1, "TR", "TURKEY" },
                    { 219, 1, "TM", "TURKMENISTAN" },
                    { 220, 1, "TC", "TURKS AND CAICOS ISLANDS" },
                    { 221, 1, "TV", "TUVALU" },
                    { 222, 1, "UG", "UGANDA" },
                    { 223, 1, "UA", "UKRAINE" },
                    { 224, 1, "AE", "UNITED ARAB EMIRATES" },
                    { 225, 1, "GB", "UNITED KINGDOM" },
                    { 226, 1, "US", "UNITED STATES" },
                    { 227, 1, "UM", "UNITED STATES MINOR OUTLYING ISLANDS" },
                    { 228, 1, "UY", "URUGUAY" },
                    { 229, 1, "UZ", "UZBEKISTAN" },
                    { 230, 1, "VU", "VANUATU" },
                    { 231, 1, "VE", "VENEZUELA" },
                    { 232, 1, "VN", "VIET NAM" },
                    { 233, 1, "VG", "VIRGIN ISLANDS, BRITISH" },
                    { 234, 1, "VI", "VIRGIN ISLANDS, U.S." },
                    { 235, 1, "WF", "WALLIS AND FUTUNA" },
                    { 236, 1, "EH", "WESTERN SAHARA" },
                    { 237, 1, "YE", "YEMEN" },
                    { 238, 1, "ZM", "ZAMBIA" },
                    { 239, 1, "ZW", "ZIMBABWE" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "UserTypeName" },
                values: new object[,]
                {
                    { 1, "Doctor" },
                    { 2, "Nurse" },
                    { 3, "Reception" },
                    { 4, "Admin" },
                    { 5, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NationalityId",
                table: "AspNetUsers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
