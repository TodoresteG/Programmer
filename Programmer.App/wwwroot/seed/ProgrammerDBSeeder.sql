USE ProgrammerDb

SET IDENTITY_INSERT Courses OFF;
SET IDENTITY_INSERT Documentations OFF;
SET IDENTITY_INSERT [Events] OFF;
SET IDENTITY_INSERT Exams OFF;
SET IDENTITY_INSERT JobTasks OFF;
SET IDENTITY_INSERT Lectures OFF;
SET IDENTITY_INSERT RequiredSkills OFF;

SET IDENTITY_INSERT [dbo].Documentations ON;

INSERT INTO Documentations (Id, [Name], XpReward, RequiredEnergy, HardSkillReward, HardSkillName, CreatedOn, IsDeleted)
VALUES (1, 'C# Tips And Tricks', 8, 5, 1.5, 'CSharp', GETDATE(), 0),
		(2, 'DataStructures Deep Dive', 10, 6, 1.4, 'DataStructures', GETDATE(), 0),
		(3, 'Algorithms', 12, 7, 1.6, 'Algorithms', GETDATE(), 0),
		(4, 'C# Testing', 6, 4, 1, 'Testing', GETDATE(), 0),
		(5, 'Data Analitics', 7, 5, 1.4, 'DatabasesAndSQL', GETDATE(), 0),
		(6, 'EfCore Optimization', 5, 4, 0.8, 'EfCore', GETDATE(), 0),
		(7, 'JS Things', 9, 6, 1.4, 'VanillaJavaScript', GETDATE(), 0),
		(8, 'HTML5 Updates', 3, 2, 0.5, 'Html', GETDATE(), 0),
		(9, 'CSS3 Advaned Techniques', 6, 4, 1, 'Css', GETDATE(), 0),
		(10, 'Asp.Net Core Best Pracitses And Architechture', 8, 5, 1.2, 'AspNetCore', GETDATE(), 0),
		(11, 'React Native with Redux', 5, 5, 1.7, 'React', GETDATE(), 0),
		(12, 'NodeJs And ExpressJs - The Clean way', 6, 5, 1.1, 'NodeJs', GETDATE(), 0)

SET IDENTITY_INSERT [dbo].Documentations OFF;
--SET IDENTITY_INSERT  [dbo].[Events] ON;

--INSERT INTO [Events] (Id, [Name], XpReward)
--VALUES (1, 'Data Structures - Event', 8),
--		(2, 'Algorithms - Event', 8),
--		(3, 'OOP - Event', 8),
--		(4, 'Testing - Event', 8),
--		(5, 'C# Tips And Tricks - Event', 8),
--		(6, 'Databases - Event', 8),
--		(7, 'EF Core - Event', 8),
--		(8, 'JS - Event', 8),
--		(9, 'Front-End Tricks - Event', 8),
--		(10, 'Asp.Net Core - Event', 8),
--		(11, 'ReactJs - Event', 8),
--		(12, 'Nodejs - Event', 8)

--SET IDENTITY_INSERT [dbo].[Events] OFF;

SET IDENTITY_INSERT [dbo].Courses ON;

INSERT INTO Courses (Id, [Name], Price, RequiredEnergy, HardSkillReward, SoftSkillReward, HardSkillName, SoftSkillName, XpReward, CreatedOn, IsDeleted)
VALUES (1, 'C# Fundamentals', 500, 5, 1, 1, 'CSharp', 'ProblemSolving', 10, GETDATE(), 0),
		(2, 'C# Advanced', 500, 5, 2.5, 1, 'CSharp', 'ProblemSolving', 15, GETDATE(), 0),
		(3, 'C# OOP', 500, 5, 1.5, 1, 'CSharp', 'ProblemSolving', 20, GETDATE(), 0),
		(4, 'Data Structures', 500, 5, 2.5, 1, 'DataStructures', 'AbstractThinking', 25, GETDATE(), 0),
		(5, 'Algorithms', 500, 5, 2.5, 1, 'Algorithms', 'ProblemSolving', 30, GETDATE(), 0),
		(6, 'Unit testing', 500, 5, 3, 1, 'Testing', 'AbstractThinking', 35, GETDATE(), 0),
		(7, 'Database Basics', 500, 5, 3, 1, 'DatabasesAndSQL', 'AbstractThinking', 40, GETDATE(), 0),
		(8, 'Ef Core', 500, 5, 3.5, 1, 'EfCore', 'ProblemSolving', 45, GETDATE(), 0),
		(9, 'JavaScript', 500, 5, 2, 1, 'VanillaJavaScript', 'ProblemSolving', 50, GETDATE(), 0),
		(10, 'HTML5', 500, 5, 2.5, 1, 'Html', 'Creativity', 55, GETDATE(), 0),
		(11, 'CSS3', 500, 5, 2.5, 1, 'Css', 'Creativity', 60, GETDATE(), 0),
		(12, 'ASP.Net Core', 500, 5, 2.5, 1, 'AspNetCore', 'AbstractThinking', 65, GETDATE(), 0),
		(13, 'ReactJs', 500, 5, 3.5, 1, 'React', 'Creativity', 70, GETDATE(), 0),
		(14, 'Nodejs', 500, 5, 4, 1, 'NodeJs', 'AbstractThinking', 75, GETDATE(), 0)

SET IDENTITY_INSERT [dbo].Courses OFF;
SET IDENTITY_INSERT [dbo].Exams ON;

INSERT INTO Exams (Id, RequiredEnergy, RequiredHardSkill, RequiredCodingSkill, CourseId, CreatedOn, IsDeleted, RequiredHardSkillName)
VALUES (1, 10, 36, 18, 1, GETDATE(), 0, 'CSharp'),
		(2, 10, 86, 28, 2, GETDATE(), 0, 'CSharp'),
		(3, 10, 158, 52, 3, GETDATE(), 0, 'CSharp'),
		(4, 10, 110, 74, 4, GETDATE(), 0, 'DataStructures'),
		(5, 10, 120, 98, 5, GETDATE(), 0, 'Algorithms'),
		(6, 10, 108, 116, 6, GETDATE(), 0, 'Testing'),
		(7, 10, 108, 132, 7, GETDATE(), 0, 'DatabasesAndSQL'),
		(8, 10, 140, 152, 8, GETDATE(), 0, 'EfCore'),
		(9, 10, 136, 186, 9, GETDATE(), 0, 'VanillaJavaScript'),
		(10, 10, 130, 212, 10, GETDATE(), 0, 'Html'),
		(11, 10, 120, 236, 11, GETDATE(), 0, 'Css'),
		(12, 10, 112, 252, 12, GETDATE(), 0, 'AspNetCore'),
		(13, 10, 112, 266, 13, GETDATE(), 0, 'React'),
		(14, 10, 112, 266, 14, GETDATE(), 0, 'NodeJs')
		

SET IDENTITY_INSERT [dbo].Exams OFF;
SET IDENTITY_INSERT [dbo].Lectures ON;

INSERT INTO Lectures (Id, [Name], CourseId, CreatedOn, IsDeleted)
VALUES (1, 'Basic Syntax, Conditional Statements and Loops', 1, GETDATE(), 0),
		(2, 'Basic Syntax, Conditional Statements and Loops - Exercise', 1, GETDATE(), 0),
		(3, 'Data types and Variables', 1, GETDATE(), 0),
		(4, 'Data types and Variables - Exercise', 1, GETDATE(), 0),
		(5, 'Arrays', 1, GETDATE(), 0),
		(6, 'Arrays - Exercise', 1, GETDATE(), 0),
		(7, 'Methods', 1, GETDATE(), 0),
		(8, 'Methods - Exercise', 1, GETDATE(), 0),
		(9, 'Advanced Arrays', 1, GETDATE(), 0),
		(10, 'Advanced Arrays - Exercise', 1, GETDATE(), 0),
		(11, 'Objects and classes', 1, GETDATE(), 0),
		(12, 'Objects and classes - Exercise', 1, GETDATE(), 0),
		(13, 'Associative arrays', 1, GETDATE(), 0),
		(14, 'Associative arrays - Exercise', 1, GETDATE(), 0),
		(15, 'Text processing', 1, GETDATE(), 0),
		(16, 'Text processing - Exercise', 1, GETDATE(), 0),
		(17, 'Regular expressions', 1, GETDATE(), 0),
		(18, 'Regular expressions - Exercise', 1, GETDATE(), 0),
		(19, 'Stacks and Queues', 2, GETDATE(), 0),
		(20, 'Stacks and Queues - Exercise', 2, GETDATE(), 0),
		(21, 'Multidimensional arrays', 2, GETDATE(), 0),
		(22, 'Multidimensional arrays - Exercise', 2, GETDATE(), 0),
		(23, 'Associative arrays Advanced', 2, GETDATE(), 0),
		(24, 'Associative arrays Advanced - Exercise', 2, GETDATE(), 0),
		(25, 'Streams, files and directories', 2, GETDATE(), 0),
		(26, 'Streams, files and directories - Exercise', 2, GETDATE(), 0),
		(27, 'Functional programming', 2, GETDATE(), 0),
		(28, 'Functional programming - Exercise', 2, GETDATE(), 0),
		(29, 'Defining classes', 3, GETDATE(), 0),
		(30, 'Defining classes - Exercise', 3, GETDATE(), 0),
		(31, 'Generics', 3, GETDATE(), 0),
		(32, 'Generics - Exercise', 3, GETDATE(), 0),
		(33, 'Iterators and Comparators', 3, GETDATE(), 0),
		(34, 'Iterators and Comparators - Exercise', 3, GETDATE(), 0),
		(35, 'Working with abstraction', 3, GETDATE(), 0),
		(36, 'Working with abstraction - Exercise', 3, GETDATE(), 0),
		(37, 'Inheritance', 3, GETDATE(), 0),
		(38, 'Inheritance - Exercise', 3, GETDATE(), 0),
		(39, 'Encapsulation', 3, GETDATE(), 0),
		(40, 'Encapsulation - Exercise', 3, GETDATE(), 0),
		(41, 'Interfaces and Abstraction', 3, GETDATE(), 0),
		(42, 'Interfaces and Abstraction - Exercise', 3, GETDATE(), 0),
		(43, 'Polymorphism', 3, GETDATE(), 0),
		(44, 'Polymorphism - Exercise', 3, GETDATE(), 0),
		(45, 'SOLID', 3, GETDATE(), 0),
		(46, 'SOLID - Exercise', 3, GETDATE(), 0),
		(47, 'Reflection and Attributes', 3, GETDATE(), 0),
		(48, 'Reflection and Attributes - Exercise', 3, GETDATE(), 0),
		(49, 'Exception and Error hangling', 3, GETDATE(), 0),
		(50, 'Exception and Error hangling - Exercise', 3, GETDATE(), 0),
		(51, 'Design patterns', 3, GETDATE(), 0),
		(52, 'Design patterns - Exercise', 3, GETDATE(), 0),
		(53, 'Linear data structures - List and LinkedList', 4, GETDATE(), 0),
		(54, 'Linear data structures - List and LinkedList - Exercise', 4, GETDATE(), 0),
		(55, 'Linear data structures - Stacks And Queues', 4, GETDATE(), 0),
		(56, 'Linear data structures - Stacks And Queues - Exercise', 4, GETDATE(), 0),
		(57, 'Basic tree data structures - Tree, Binary tree', 4, GETDATE(), 0),
		(58, 'Basic tree data structures - Tree, Binary tree - Exercise', 4, GETDATE(), 0),
		(59, 'Binary Search trees', 4, GETDATE(), 0),
		(60, 'Binary Search trees - Exercise', 4, GETDATE(), 0),
		(61, 'Heaps and priority queue', 4, GETDATE(), 0),
		(62, 'Heaps and priority queue - Exercise', 4, GETDATE(), 0),
		(63, 'B-Trees and Red-Black trees', 4, GETDATE(), 0),
		(64, 'B-Trees and Red-Black trees - Exercise', 4, GETDATE(), 0),
		(65, 'AA-Trees and AVL trees', 4, GETDATE(), 0),
		(66, 'AA-Trees and AVL trees - Exercise', 4, GETDATE(), 0),
		(67, 'Rope and Trie', 4, GETDATE(), 0),
		(68, 'Rope and Trie - Exercise', 4, GETDATE(), 0),
		(69, 'Quad Trees, K-D Trees, Interval trees', 4, GETDATE(), 0),
		(70, 'Quad Trees, K-D Trees, Interval trees - Exercise', 4, GETDATE(), 0),
		(71, 'Hash tables', 4, GETDATE(), 0),
		(72, 'Hash tables - Exercise', 4, GETDATE(), 0),
		(73, 'Combining data structures', 4, GETDATE(), 0),
		(74, 'Combining data structures - Exercise', 4, GETDATE(), 0),
		(75, 'Recursion', 5, GETDATE(), 0),
		(76, 'Recursion - Exercise', 5, GETDATE(), 0),
		(77, 'Sorting Algorithms', 5, GETDATE(), 0),
		(78, 'Sorting Algorithms - Exercise', 5, GETDATE(), 0),
		(79, 'Searching Algorithms', 5, GETDATE(), 0),
		(80, 'Searching Algorithms - Exercise', 5, GETDATE(), 0),
		(81, 'Combinatorial Algorithms', 5, GETDATE(), 0),
		(82, 'Combinatorial Algorithms - Exercise', 5, GETDATE(), 0),
		(83, 'Greedy Algorithms', 5, GETDATE(), 0),
		(84, 'Greedy Algorithms - Exercise', 5, GETDATE(), 0),
		(85, 'Dynamic Programming', 5, GETDATE(), 0),
		(86, 'Dynamic Programming - Exercise', 5, GETDATE(), 0),
		(87, 'Dynamic Programming - Part 2', 5, GETDATE(), 0),
		(88, 'Dynamic Programming - Part 2 - Exercise', 5, GETDATE(), 0),
		(89, 'Graphs and Graphs Algorithms', 5, GETDATE(), 0),
		(90, 'Graphs and Graphs Algorithms - Exercise', 5, GETDATE(), 0),
		(91, 'Advanced Graphs and Graphs Algorithms - Part 1', 5, GETDATE(), 0),
		(92, 'Advanced Graphs and Graphs Algorithms - Part 1 - Exercise', 5, GETDATE(), 0),
		(93, 'Advanced Graphs and Graphs Algorithms - Part 2', 5, GETDATE(), 0),
		(94, 'Advanced Graphs and Graphs Algorithms - Part 2 - Exercise', 5, GETDATE(), 0),
		(95, 'Problem Solving Methodology', 5, GETDATE(), 0),
		(96, 'Problem Solving Methodology - Exercise', 5, GETDATE(), 0),
		(97, 'Solving Practical problems', 5, GETDATE(), 0),
		(98, 'Solving Practical problems - Exercise', 5, GETDATE(), 0),
		(99, 'Introduction to Unit testing', 6, GETDATE(), 0),
		(100, 'Introduction to Unit testing - Exercise', 6, GETDATE(), 0),
		(101, 'Fundamentals of Unit testing', 6, GETDATE(), 0),
		(102, 'Fundamentals of Unit testing - Exercise', 6, GETDATE(), 0),
		(103, 'Core unit testing techniques', 6, GETDATE(), 0),
		(104, 'Core unit testing techniques - Exercise', 6, GETDATE(), 0),
		(105, 'Breaking External dependencies', 6, GETDATE(), 0),
		(106, 'Breaking External dependencies - Exercise', 6, GETDATE(), 0),
		(107, 'Introduction to TDD', 6, GETDATE(), 0),
		(108, 'Introduction to TDD - Exercise', 6, GETDATE(), 0),
		(109, 'TDD in Action', 6, GETDATE(), 0),
		(110, 'TDD in Action - Exercise', 6, GETDATE(), 0),
		(111, 'Katas and TDD', 6, GETDATE(), 0),
		(112, 'Katas and TDD - Exercise', 6, GETDATE(), 0),
		(113, 'Writing Test Modules', 6, GETDATE(), 0),
		(114, 'Writing Test Modules - Exercise', 6, GETDATE(), 0),
		(115, 'Acceptance and Integration Tests', 6, GETDATE(), 0),
		(116, 'Acceptance and Integration Tests - Exercise', 6, GETDATE(), 0),
		(117, 'Database Introduction', 7, GETDATE(), 0),
		(118, 'Database Introduction - Exercise', 7, GETDATE(), 0),
		(119, 'Data Definition and Data types', 7, GETDATE(), 0),
		(120, 'Data Definition and Data types - Exercise', 7, GETDATE(), 0),
		(121, 'Basic CRUD', 7, GETDATE(), 0),
		(122, 'Basic CRUD - Exercise', 7, GETDATE(), 0),
		(123, 'Built-in functions', 7, GETDATE(), 0),
		(124, 'Built-in functions - Exercise', 7, GETDATE(), 0),
		(125, 'Data aggregation', 7, GETDATE(), 0),
		(126, 'Data aggregation - Exercise', 7, GETDATE(), 0),
		(127, 'Table relations', 7, GETDATE(), 0),
		(128, 'Table relations - Exercise', 7, GETDATE(), 0),
		(129, 'Subqueries and Joins', 7, GETDATE(), 0),
		(130, 'Subqueries and Joins - Exercise', 7, GETDATE(), 0),
		(131, 'Database Programmability', 7, GETDATE(), 0),
		(132, 'Database Programmability - Exercise', 7, GETDATE(), 0),
		(133, 'Triggers and Transactions', 7, GETDATE(), 0),
		(134, 'Triggers and Transactions - Exercise', 7, GETDATE(), 0),
		(135, 'Db Apps Introduction', 8, GETDATE(), 0),
		(136, 'Db Apps Introduction - Exercise', 8, GETDATE(), 0),
		(137, 'ORM Fundamentals', 8, GETDATE(), 0),
		(138, 'ORM Fundamentals - Exercise', 8, GETDATE(), 0),
		(139, 'Ef Core Introduction', 8, GETDATE(), 0),
		(140, 'Ef Core Introduction - Exercise', 8, GETDATE(), 0),
		(141, 'Code-First', 8, GETDATE(), 0),
		(142, 'Code-First - Exercise', 8, GETDATE(), 0),
		(143, 'Entity Relations', 8, GETDATE(), 0),
		(144, 'Entity Relations - Exercise', 8, GETDATE(), 0),
		(145, 'Advanced Querying', 8, GETDATE(), 0),
		(146, 'Advanced Querying - Exercise', 8, GETDATE(), 0),
		(147, 'C# Automapper', 8, GETDATE(), 0),
		(148, 'C# Automapper - Exercise', 8, GETDATE(), 0),
		(149, 'JSON Processing', 8, GETDATE(), 0),
		(150, 'JSON Processing - Exercise', 8, GETDATE(), 0),
		(151, 'XML Processing', 8, GETDATE(), 0),
		(152, 'XML Processing - Exercise', 8, GETDATE(), 0),
		(153, 'Best Practises and Architechture', 8, GETDATE(), 0),
		(154, 'Best Practises and Architechture - Exercise', 8, GETDATE(), 0),
		(155, 'Syntax, Funcions and Statements', 9, GETDATE(), 0),
		(156, 'Syntax, Funcions and Statements - Exercise', 9, GETDATE(), 0),
		(157, 'Objects', 9, GETDATE(), 0),
		(158, 'Objects - Exercise', 9, GETDATE(), 0),
		(159, 'Arrays', 9, GETDATE(), 0),
		(160, 'Arrays - Exercise', 9, GETDATE(), 0),
		(161, 'Advanced Functions', 9, GETDATE(), 0),
		(162, 'Advanced Functions - Exercise', 9, GETDATE(), 0),
		(163, 'DOM', 9, GETDATE(), 0),
		(164, 'DOM - Exercise', 9, GETDATE(), 0),
		(165, 'DOM Manipulations', 9, GETDATE(), 0),
		(166, 'DOM Manipulations - Exercise', 9, GETDATE(), 0),
		(167, 'Classes', 9, GETDATE(), 0),
		(168, 'Classes - Exercise', 9, GETDATE(), 0),
		(169, 'String and Regex', 9, GETDATE(), 0),
		(170, 'String and Regex - Exercise', 9, GETDATE(), 0),
		(171, 'This', 9, GETDATE(), 0),
		(172, 'This - Exercise', 9, GETDATE(), 0),
		(173, 'Object composition', 9, GETDATE(), 0),
		(174, 'Object composition - Exercise', 9, GETDATE(), 0),
		(175, 'Prototypes and Inheritance', 9, GETDATE(), 0),
		(176, 'Prototypes and Inheritance - Exercise', 9, GETDATE(), 0),
		(177, 'Rest services and AJAX', 9, GETDATE(), 0),
		(178, 'Rest services and AJAX - Exercise', 9, GETDATE(), 0),
		(179, 'Asynchronius programming', 9, GETDATE(), 0),
		(180, 'Asynchronius programming - Exercise', 9, GETDATE(), 0),
		(181, 'Templating', 9, GETDATE(), 0),
		(182, 'Templating - Exercise', 9, GETDATE(), 0),
		(183, 'Routing and Architechture', 9, GETDATE(), 0),
		(184, 'Routing and Architechture - Exercise', 9, GETDATE(), 0),
		(185, 'Single Page Application', 9, GETDATE(), 0),
		(186, 'Single Page Application - Exercise', 9, GETDATE(), 0),
		(187, 'WebPack', 9, GETDATE(), 0),
		(188, 'WebPack - Exercise', 9, GETDATE(), 0),
		(189, 'Introduction to HTML5', 10, GETDATE(), 0),
		(190, 'Introduction to HTML5 - Exercise', 10, GETDATE(), 0),
		(191, 'HTML Tags', 10, GETDATE(), 0),
		(192, 'HTML Tags - Exercise', 10, GETDATE(), 0),
		(193, 'HTML Structure', 10, GETDATE(), 0),
		(194, 'HTML Structure - Exercise', 10, GETDATE(), 0),
		(195, 'Semantic HTML', 10, GETDATE(), 0),
		(196, 'Semantic HTML - Exercise', 10, GETDATE(), 0),
		(197, 'HTML Advanced', 10, GETDATE(), 0),
		(198, 'HTML Advanced - Exercise', 10, GETDATE(), 0),
		(199, 'Introduction to CSS3', 11, GETDATE(), 0),
		(200, 'Introduction to CSS3 - Exercise', 11, GETDATE(), 0),
		(201, 'CSS and Typography', 11, GETDATE(), 0),
		(202, 'CSS and Typography - Exercise', 11, GETDATE(), 0),
		(203, 'CSS Box Model', 11, GETDATE(), 0),
		(204, 'CSS Box Model - Exercise', 11, GETDATE(), 0),
		(205, 'Position And Float', 11, GETDATE(), 0),
		(206, 'Position And Float - Exercise', 11, GETDATE(), 0),
		(207, 'FlexBox', 11, GETDATE(), 0),
		(208, 'FlexBox - Exercise', 11, GETDATE(), 0),
		(209, 'Media Queries', 11, GETDATE(), 0),
		(210, 'Media Queries - Exercise', 11, GETDATE(), 0),
		(211, 'Dev Workflows and Tools', 11, GETDATE(), 0),
		(212, 'Dev Workflows and Tools - Exercise', 11, GETDATE(), 0),
		(213, 'CSS variables and Icon fronts', 11, GETDATE(), 0),
		(214, 'CSS variables and Icon fronts - Exercise', 11, GETDATE(), 0),
		(215, 'CSS Transitions and Animations', 11, GETDATE(), 0),
		(216, 'CSS Transitions and Animations - Exercise', 11, GETDATE(), 0),
		(217, 'SASS', 11, GETDATE(), 0),
		(218, 'SASS - Exercise', 11, GETDATE(), 0),
		(219, 'CSS layout grid', 11, GETDATE(), 0),
		(220, 'CSS layout grid - Exercise', 11, GETDATE(), 0),
		(221, 'Building layouts', 11, GETDATE(), 0),
		(222, 'Building layouts - Exercise', 11, GETDATE(), 0),
		(223, 'AspNetCore Introduction', 12, GETDATE(), 0),
		(224, 'AspNetCore Introduction - Exercise', 12, GETDATE(), 0),
		(225, 'Razor Views', 12, GETDATE(), 0),
		(226, 'Razor Views - Exercise', 12, GETDATE(), 0),
		(227, 'Application Flow', 12, GETDATE(), 0),
		(228, 'Application Flow - Exercise', 12, GETDATE(), 0),
		(229, 'Filters and Middleware', 12, GETDATE(), 0),
		(230, 'Filters and Middleware - Exercise', 12, GETDATE(), 0),
		(231, 'Working with Data', 12, GETDATE(), 0),
		(232, 'Working with Data - Exercise', 12, GETDATE(), 0),
		(233, 'Web API', 12, GETDATE(), 0),
		(234, 'Web API - Exercise', 12, GETDATE(), 0),
		(235, 'Security and Identity', 12, GETDATE(), 0),
		(236, 'Security and Identity - Exercise', 12, GETDATE(), 0),
		(237, 'Project Architechture', 12, GETDATE(), 0),
		(238, 'Project Architechture - Exercise', 12, GETDATE(), 0),
		(239, 'Advaced Topics', 12, GETDATE(), 0),
		(240, 'Advaced Topics - Exercise', 12, GETDATE(), 0),
		(241, 'SignalR', 12, GETDATE(), 0),
		(242, 'SignalR - Exercise', 12, GETDATE(), 0),
		(243, 'Azure, Deployment and CI', 12, GETDATE(), 0),
		(244, 'Azure, Deployment and CI - Exercise', 12, GETDATE(), 0),
		(245, 'Blazor', 12, GETDATE(), 0),
		(246, 'Blazor - Exercise', 12, GETDATE(), 0),
		(247, 'Intro to ReactJs and JSX', 13, GETDATE(), 0),
		(248, 'Intro to ReactJs and JSX - Exercise', 13, GETDATE(), 0),
		(249, 'Components Fundamentals', 13, GETDATE(), 0),
		(250, 'Components Fundamentals - Exercise', 13, GETDATE(), 0),
		(251, 'Components Advanced', 13, GETDATE(), 0),
		(252, 'Components Advanced - Exercise', 13, GETDATE(), 0),
		(253, 'Routing', 13, GETDATE(), 0),
		(254, 'Routing - Exercise', 13, GETDATE(), 0),
		(255, 'Forms', 13, GETDATE(), 0),
		(256, 'Forms - Exercise', 13, GETDATE(), 0),
		(257, 'React Hooks', 13, GETDATE(), 0),
		(258, 'React Hooks - Exercise', 13, GETDATE(), 0),
		(259, 'Authentication', 13, GETDATE(), 0),
		(260, 'Authentication - Exercise', 13, GETDATE(), 0),
		(261, 'Advanced Techniques', 13, GETDATE(), 0),
		(262, 'Advanced Techniques - Exercise', 13, GETDATE(), 0),
		(263, 'Intro to Nodejs', 14, GETDATE(), 0),
		(264, 'Intro to Nodejs - Exercise', 14, GETDATE(), 0),
		(265, 'Nodejs Streams and Unitlities', 14, GETDATE(), 0),
		(266, 'Nodejs Streams and Unitlities - Exercise', 14, GETDATE(), 0),
		(267, 'ExpressJs and Templating', 14, GETDATE(), 0),
		(268, 'ExpressJs and Templating - Exercise', 14, GETDATE(), 0),
		(269, 'NoSQL', 14, GETDATE(), 0),
		(270, 'NoSQL - Exercise', 14, GETDATE(), 0),
		(271, 'Session and Authentication', 14, GETDATE(), 0),
		(272, 'Session and Authentication - Exercise', 14, GETDATE(), 0),
		(273, 'Validation and Error handling', 14, GETDATE(), 0),
		(274, 'Validation and Error handling - Exercise', 14, GETDATE(), 0),
		(275, 'Rest API', 14, GETDATE(), 0),
		(276, 'Rest API - Exercise', 14, GETDATE(), 0)

SET IDENTITY_INSERT [dbo].Lectures OFF;

