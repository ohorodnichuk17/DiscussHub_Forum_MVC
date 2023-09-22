using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum_MVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AmountOfTopics = table.Column<int>(type: "int", nullable: false),
                    VisibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TopicsOfPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VisibilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicsOfPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicsOfPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true),
                    TopicOfPostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_TopicsOfPosts_TopicOfPostId",
                        column: x => x.TopicOfPostId,
                        principalTable: "TopicsOfPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    PostStatisticsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_PostStatistics_PostStatisticsId",
                        column: x => x.PostStatisticsId,
                        principalTable: "PostStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AmountOfTopics", "Name", "VisibilityStatus" },
                values: new object[,]
                {
                    { 1, 5, "General Discussions", "Active" },
                    { 2, 3, "Coding Challenges and Solutions", "Active" },
                    { 3, 4, "Web Development", "Active" },
                    { 4, 9, "Mobile App Development", "Suspended" },
                    { 5, 21, "Game Development", "Suspended" },
                    { 6, 7, "Software Engineering", "Active" },
                    { 7, 2, "Programming Languages", "Active" },
                    { 8, 8, "Database Management", "Active" },
                    { 9, 19, "Algorithms and Data Structures", "Active" },
                    { 10, 6, "DevOps and Continuous Integration", "Suspended" },
                    { 11, 3, "Front-end Development", "Active" },
                    { 12, 4, "Back-end Development", "Active" },
                    { 13, 1, "Machine Learning and AI", "Suspended" },
                    { 14, 14, "Cybersecurity", "Active" },
                    { 15, 9, "Code Reviews and Feedback", "Suspended" }
                });

            migrationBuilder.InsertData(
                table: "PostStatistics",
                columns: new[] { "Id", "DislikeCount", "LikeCount" },
                values: new object[,]
                {
                    { 1, 3, 10 },
                    { 2, 2, 8 },
                    { 3, 1, 12 },
                    { 4, 0, 15 },
                    { 5, 2, 11 },
                    { 6, 1, 9 },
                    { 7, 0, 14 },
                    { 8, 3, 13 },
                    { 9, 2, 10 },
                    { 10, 1, 8 },
                    { 11, 0, 7 },
                    { 12, 2, 6 },
                    { 13, 1, 9 },
                    { 14, 0, 11 },
                    { 15, 2, 14 },
                    { 16, 1, 12 },
                    { 17, 2, 10 },
                    { 18, 0, 8 },
                    { 19, 1, 7 },
                    { 20, 2, 9 },
                    { 21, 3, 15 },
                    { 22, 1, 13 },
                    { 23, 0, 11 },
                    { 24, 2, 10 },
                    { 25, 1, 8 },
                    { 26, 0, 7 },
                    { 27, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "PostStatistics",
                columns: new[] { "Id", "DislikeCount", "LikeCount" },
                values: new object[,]
                {
                    { 28, 1, 5 },
                    { 29, 0, 4 },
                    { 30, 2, 3 },
                    { 31, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ImageUrl", "Password", "PostStatisticsId", "Username" },
                values: new object[,]
                {
                    { 3, "mikejohnson@example.com", "~/img/people/2.jpg", "Pa$$w0rd#2023", null, "MikeJohnson" },
                    { 9, "robertlee@example.com", "~/img/people/5.jpg", "H@ppyC0der", null, "RobertLee" }
                });

            migrationBuilder.InsertData(
                table: "TopicsOfPosts",
                columns: new[] { "Id", "Description", "Name", "UserId", "VisibilityStatus" },
                values: new object[,]
                {
                    { 3, "A step-by-step guide for beginners to start learning Python programming from scratch.", "Beginner's Guide to Python Programming", 3, "Active" },
                    { 9, "Explore adrenaline-pumping travel destinations worldwide for adventure seekers.", "Travel Destinations for Adventure Enthusiasts", 9, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "ImageUrl", "Password", "PostStatisticsId", "Username" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "~/img/people/1.png", "StrongP@ssw0rd", 30, "JohnDoe" },
                    { 2, "janesmith@example.com", "~/img/people/people/1w.jpg", "Secure1234!", 20, "JaneSmith" },
                    { 4, "sarahbrown@example.com", "~/img/people/2w.jpg", "C0dingRocks!", 28, "SarahBrown" },
                    { 5, "davidclark@example.com", "~/img/people/3.jpg", "TechGeek#123", 26, "DavidClark" },
                    { 6, "emilywilson@example.com", "~/img/people/3w.jpg", "Pr0gramm3r@", 2, "EmilyWilson" },
                    { 7, "alexgarcia@example.com", "~/img/people/4.jpg", "D3v3l0pment$", 13, "AlexGarcia" },
                    { 8, "lisadavis@example.com", "~/img/people/4w.jpg", "DataSecurity#1", 15, "LisaDavis" },
                    { 10, "karenanderson@example.com", "~/img/people/5w.jpg", "Innov8tive&", 8, "KarenAnderson" },
                    { 11, "marktaylor@example.com", "~/img/people/6.jpg", "MasterM1nd!", 27, "MarkTaylor" },
                    { 12, "oliviawhite@example.com", "~/img/people/6w.jpg", "P@ssionateD3v", 14, "OliviaWhite" },
                    { 13, "brianmiller@example.com", "~/img/people/7.jpg", "Creat1v3C0de", 11, "BrianMiller" },
                    { 14, "sophiajohnson@example.com", "~/img/people/7w.jpg", "2FA4Security", 6, "SophiaJohnson" },
                    { 15, "williamwilson@example.com", "~/img/people/8.jpg", "G3n!usC0d3r", 12, "WilliamWilson" },
                    { 16, "jessicamoore@example.com", "~/img/people/8w.jpg", "DebugGuru#7", 17, "JessicaMoore" },
                    { 17, "danielbrown@example.com", "~/img/people/9.jpg", "WebM@ster$2023", 18, "DanielBrown" },
                    { 18, "emmamartinez@example.com", "~/img/people/9w.jpg", "0penS0urce", 23, "EmmaMartinez" },
                    { 19, "michaelsmith@example.com", "~/img/people/10.jpg", "C0mput3rWh1z", 31, "MichaelSmith" },
                    { 20, "avaharris@example.com", "~/img/people/10w.jpg", "H@rdw@r3L0v3r", 7, "AvaHarris" },
                    { 21, "jamesjohnson@example.com", "~/img/people/11.jpg", "Alph@Num3ric", 9, "JamesJohnson" },
                    { 22, "miataylor@example.com", "~/img/people/11w.jpg", "Art1f1c1@lInt3ll1g3nc3", 21, "MiaTaylor" },
                    { 23, "ethanwilliams@example.com", "~/img/people/12.jpg", "B1gData&R3search", 1, "EthanWilliams" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "PostStatisticsId", "Text", "Title", "TopicOfPostId", "UserId" },
                values: new object[] { 27, 1, null, 27, "Recent advances in energy storage technologies for renewable energy sources.", "Advances in Renewable Energy Storage", 3, 3 });

            migrationBuilder.InsertData(
                table: "TopicsOfPosts",
                columns: new[] { "Id", "Description", "Name", "UserId", "VisibilityStatus" },
                values: new object[,]
                {
                    { 1, "Explore the basics of machine learning and its applications in real-world scenarios.", "Introduction to Machine Learning", 1, "Active" },
                    { 2, "Discover the latest trends and technologies shaping the world of web development in 2023.", "Web Development Trends in 2023", 2, "Active" },
                    { 4, "Learn essential cybersecurity practices to protect your digital assets and online privacy.", "Cybersecurity Best Practices", 4, "Active" },
                    { 5, "Explore the principles and techniques behind creating visually appealing and user-friendly mobile app interfaces.", "The Art of Mobile App Design", 5, "Active" },
                    { 6, "Delve into how data science can be used to extract valuable insights and drive decision-making in business.", "Data Science for Business Insights", 6, "Active" },
                    { 7, "Dive deep into popular JavaScript frameworks like React, Angular, and Vue.js to build dynamic web applications.", "Mastering JavaScript Frameworks", 7, "Active" },
                    { 8, "Discover tips and tricks for maintaining a healthy lifestyle, including diet, exercise, and stress management.", "Healthy Lifestyle Habits", 8, "Active" },
                    { 10, "Learn about the world of cryptocurrencies, investment strategies, and the latest developments in the crypto market.", "Investing in Cryptocurrencies", 10, "Active" },
                    { 11, "Embark on a cosmic journey to explore the wonders of our universe, from distant galaxies to celestial phenomena.", "Exploring Space and Astronomy", 11, "Active" },
                    { 12, "Explore how AI is transforming the healthcare industry and improving patient care.", "Artificial Intelligence in Healthcare", 12, "Active" },
                    { 13, "Dive into the differences and similarities between frontend and backend development.", "Frontend vs. Backend Development", 13, "Active" },
                    { 14, "Discover the potential applications and advancements in virtual reality technology.", "The Future of Virtual Reality", 14, "Active" },
                    { 15, "Learn how machine learning is used to analyze and process human language.", "Machine Learning for Natural Language Processing", 15, "Active" },
                    { 16, "Explore best practices for building web applications that can handle high traffic and scale efficiently.", "Building Scalable Web Applications", 16, "Active" },
                    { 17, "Discuss the implications of 5G technology on the Internet of Things (IoT) ecosystem.", "The Impact of 5G on IoT", 17, "Active" },
                    { 18, "A beginner's guide to creating meaningful visualizations from data.", "Getting Started with Data Visualization", 18, "Active" },
                    { 19, "Learn about ethical hacking practices and how to secure your systems through penetration testing.", "Ethical Hacking and Penetration Testing", 19, "Active" },
                    { 20, "Explore the dynamics of e-commerce, from online marketplaces to digital marketing strategies.", "The World of E-Commerce", 20, "Active" },
                    { 21, "Discover tools and frameworks for developing mobile apps that work on multiple platforms.", "Building Cross-Platform Mobile Apps", 21, "Active" },
                    { 22, "Learn about the principles of quantum computing and its potential to revolutionize computing.", "Introduction to Quantum Computing", 22, "Active" },
                    { 23, "Explore the creative and technical aspects of designing engaging and immersive video games.", "The Art of Game Design", 23, "Active" },
                    { 24, "Discover how machine learning models can identify and classify images with high accuracy.", "Machine Learning for Image Recognition", 19, "Active" },
                    { 25, "Discuss sustainable energy options, such as solar, wind, and hydropower, for a greener future.", "Exploring Renewable Energy Sources", 21, "Active" },
                    { 26, "Dive into the science of encryption and decryption, essential for secure communication and data protection.", "The World of Cryptography", 23, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DislikeCount", "ImageUrl", "LikeCount", "PostId", "PostStatisticsId", "Text", "UserId" },
                values: new object[] { 13, 1, null, 12, 27, null, "Quantum cryptography is fascinating. It's the future of security.", 8 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "PostStatisticsId", "Text", "Title", "TopicOfPostId", "UserId" },
                values: new object[,]
                {
                    { 1, 9, null, 1, "Explore some fundamental machine learning algorithms for those new to the field.", "Machine Learning Algorithms for Beginners", 12, 3 },
                    { 2, 11, null, 2, "Tips for selecting the most suitable backend framework for your web application.", "Choosing the Right Backend Framework", 13, 4 },
                    { 3, 6, null, 3, "Learn how to design VR experiences that captivate users and provide a sense of presence.", "Creating Immersive Virtual Reality Experiences", 14, 5 },
                    { 4, 7, null, 4, "A comprehensive guide to NLP techniques and libraries in the Python ecosystem.", "Natural Language Processing with Python", 15, 6 },
                    { 5, 3, null, 5, "Strategies and architectures to handle large volumes of traffic on your website.", "Scalability Strategies for High-Traffic Websites", 16, 7 },
                    { 6, 14, null, 6, "Exploring security challenges and solutions in the context of 5G-connected IoT devices.", "IoT Security in the 5G Era", 17, 8 },
                    { 7, 8, null, 7, "An overview and comparison of popular data visualization tools available today.", "Data Visualization Tools Comparison", 18, 9 },
                    { 8, 14, null, 8, "Best practices and methodologies for conducting effective penetration tests.", "Penetration Testing Best Practices", 19, 10 },
                    { 9, 3, null, 9, "Tips and techniques for optimizing your e-commerce website for search engines.", "E-Commerce SEO Strategies", 20, 11 },
                    { 10, 4, null, 10, "A guide to building cross-platform mobile apps using the Flutter framework.", "Cross-Platform Mobile App Development with Flutter", 21, 12 },
                    { 11, 7, null, 11, "An exploration of the potential applications and challenges of quantum computing.", "Quantum Computing: Potential and Challenges", 22, 13 },
                    { 12, 5, null, 12, "Key principles for designing games that keep players engaged and entertained.", "Game Design Principles for Engaging Gameplay", 23, 14 },
                    { 13, 9, null, 13, "A deep dive into building image recognition models using CNNs and deep learning.", "Image Recognition Using Convolutional Neural Networks", 24, 15 },
                    { 14, 1, null, 14, "Exploring renewable energy sources as a viable option for a greener and sustainable future.", "Renewable Energy Solutions for a Sustainable Future", 25, 16 },
                    { 15, 14, null, 15, "The role of cryptography in ensuring secure communication and data protection.", "Cryptography in Communication and Security", 26, 17 },
                    { 16, 1, null, 16, "Exploring how artificial intelligence is revolutionizing healthcare and medical diagnostics.", "The Impact of AI in Healthcare", 24, 15 },
                    { 17, 11, null, 17, "The challenges and potential future of space travel, including Mars exploration.", "Space Travel: Challenges and Future Prospects", 25, 16 },
                    { 18, 8, null, 18, "The applications of blockchain technology beyond cryptocurrencies, such as supply chain and voting systems.", "Blockchain Technology: Beyond Cryptocurrency", 18, 17 },
                    { 19, 6, null, 19, "Recent advancements in 3D printing technology and its impact on various industries.", "Advancements in 3D Printing", 18, 18 },
                    { 20, 6, null, 20, "How remote and hybrid work models are shaping the future of work and office culture.", "The Future of Work: Remote and Hybrid Models", 25, 19 },
                    { 21, 1, null, 21, "Exploring sustainable agriculture practices and their importance in food production.", "Sustainable Agriculture Practices", 8, 20 },
                    { 22, 1, null, 22, "The growth and future of electric vehicles as an eco-friendly transportation option.", "Rise of Electric Vehicles (EVs)", 1, 21 },
                    { 23, 7, null, 23, "How augmented reality is transforming education and enhancing learning experiences.", "Augmented Reality in Education", 22, 22 },
                    { 24, 11, null, 24, "The challenges and possibilities of human colonization on Mars.", "Mars Colonization: Challenges and Possibilities", 12, 23 },
                    { 25, 8, null, 25, "The role of AI in financial markets, risk assessment, and fraud detection.", "Artificial Intelligence in Finance", 26, 1 },
                    { 26, 11, null, 26, "The evolution of UX design principles and their impact on digital products.", "The Evolution of User Experience (UX) Design", 22, 2 },
                    { 28, 14, null, 28, "The potential of quantum cryptography to revolutionize data security.", "The Future of Quantum Cryptography", 4, 4 },
                    { 29, 1, null, 29, "Innovative technologies transforming agriculture and increasing crop yield.", "Agricultural Technology Innovations", 2, 5 },
                    { 30, 11, null, 30, "How smart city technologies are shaping the future of urban living.", "Smart Cities: Building the Future", 21, 6 },
                    { 31, 8, null, 31, "Exploring ethical considerations in AI development and deployment.", "The Ethics of Artificial Intelligence", 20, 7 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DislikeCount", "ImageUrl", "LikeCount", "PostId", "PostStatisticsId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 0, null, 8, 15, null, "Great post! AI in healthcare has so much potential.", 16 },
                    { 2, 1, null, 6, 16, null, "I've always been fascinated by space travel. Thanks for sharing this.", 17 },
                    { 3, 2, null, 10, 17, null, "Blockchain has the power to change everything. Exciting times ahead!", 18 },
                    { 4, 0, null, 7, 18, null, "3D printing is a game-changer. Can't wait to see what's next.", 19 },
                    { 5, 1, null, 9, 19, null, "Remote work is here to stay. It's convenient and offers more flexibility.", 20 },
                    { 6, 3, null, 11, 20, null, "Sustainability is crucial in agriculture. We need to protect the environment.", 21 },
                    { 7, 2, null, 12, 21, null, "Electric vehicles are the future of transportation. Great article!", 22 },
                    { 8, 1, null, 9, 22, null, "AR in education can make learning more engaging for students.", 23 },
                    { 9, 0, null, 14, 23, null, "Mars colonization would be a monumental achievement for humanity.", 15 },
                    { 10, 2, null, 10, 24, null, "AI is changing the finance industry rapidly. Great insights!", 16 },
                    { 11, 1, null, 11, 25, null, "UX design keeps evolving to create better user experiences.", 12 },
                    { 12, 0, null, 13, 26, null, "Renewable energy storage is critical for a sustainable future.", 14 },
                    { 14, 3, null, 15, 28, null, "Agricultural technology is advancing rapidly. We need more innovation.", 9 },
                    { 15, 2, null, 14, 29, null, "Smart cities are the answer to urban challenges. Great article!", 11 },
                    { 16, 0, null, 16, 30, null, "Ethical AI development is crucial for responsible technology.", 19 },
                    { 17, 1, null, 13, 31, null, "Biotechnology is revolutionizing healthcare and beyond.", 22 },
                    { 18, 3, null, 15, 31, null, "Private companies and government agencies both have roles in space exploration.", 23 },
                    { 19, 2, null, 17, 21, null, "Telemedicine is making healthcare more accessible to remote areas.", 21 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostStatisticsId",
                table: "Comments",
                column: "PostStatisticsId",
                unique: true,
                filter: "[PostStatisticsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostStatisticsId",
                table: "Posts",
                column: "PostStatisticsId",
                unique: true,
                filter: "[PostStatisticsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicOfPostId",
                table: "Posts",
                column: "TopicOfPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsOfPosts_UserId",
                table: "TopicsOfPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostStatisticsId",
                table: "Users",
                column: "PostStatisticsId",
                unique: true,
                filter: "[PostStatisticsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TopicsOfPosts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PostStatistics");
        }
    }
}
