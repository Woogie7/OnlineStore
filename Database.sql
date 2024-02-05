USE [HuntOnlineStore]
GO
/****** Object:  Table [dbo].[product]    Script Date: 05.02.2024 12:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[price] [decimal](7, 2) NULL,
	[typeProduct] [int] NULL,
	[image] [nvarchar](50) NULL,
 CONSTRAINT [PK__product__3213E83F93127946] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 05.02.2024 12:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[password] [nvarchar](255) NULL,
	[name] [nvarchar](50) NULL,
	[role] [int] NULL,
	[email] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (1, N'Спиннинг Zetrix', N'SOLVER – новая линейка спиннинговых удилищ от бренда Zetrix, наглядно показывающая, что и недорогое может быть классным. Стоит только взять SOLVER в руку, как сразу обращаешь внимание на непривычное бюджету сочетание веса и строя: каждая палочка оставляет приятное впечатление и характеристиками буквально стремится к своим «старшим братьям».', CAST(1.00 AS Decimal(7, 2)), 0, N'spinning_zetrix_1.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (2, N'Манок Faulks на утку орех', N'Это классический (духовой) манок на утку с двойным пищиком, один из которых работает как сурдина для мягкого звучания манка. Идеален для работы в лесу, где требуется мягкий тон, а так же в случаях, когда резкое и громкое приманивание отпугивает птицу. Это одна из популярных моделей среди манков. Манок Faulk''s DR66 изготовлен из натуральной ореховой древесины.', CAST(2823.00 AS Decimal(7, 2)), 5, N'manok_faulks_na_utku_orekh.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (3, N'Удилище DAM Fighter', N'Удилище DAM Fighter pro combo tele pole 300 w/float set.

- Включает в комплекте поплавок, леску 0,14 мм и крючок;

- Удилище готово к рыбалке;

- Поставляется в комплекте с резинкой.', CAST(557.00 AS Decimal(7, 2)), 0, N'udilishche_dam_fighter.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (4, N'Спиннинг Волжанка Стилет 2м 0,5-5гр', N'Название этой линейки спиннингов класса УЛ говорит само за себя — быстрота, легкость, изящность и неотразимость! Удилище предназначено, прежде всего, для форелевой рыбалки, и ловли других рыб, отличающихся мощной и молниеносной атакой - головля, хариуса, ленка, окуня. Спиннинг прекрасно работает с разнообразными видами легких приманок, в том числе и с неогруженой «резиной».', CAST(3443.00 AS Decimal(7, 2)), 0, N'spinning_volzhanka_stilet.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (5, N'Свисток Elles для подзыва собак 2 тона пластик', N'Свисток на два тона для подзывания собаки. Каждый экземпляр обладает индивидуальным звуком, к которому привыкает собака, и который она не перепутает с чужим свистком. Два тона (высокий и низкий), звучащие одновременно, значительно повышают надежность узнавания собакой свистка на большом расстоянии.', CAST(473.00 AS Decimal(7, 2)), 5, N'svistok_elles_dlya_podzyva_sobak.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (6, N'Катушка Daiwa 19 Ninja BG LT 2500', N'Концепция катушек Light&Tough – идеальное сочетание лёгкости и прочности. Она гарантирует, что Ninja BG LT выдержит самые жесткие и сложные условия современной спиннинговой рыбалки, а конструкция компактного корпуса обеспечит максимально возможную стабильность работы механизма и устойчивый плавный ход катушки в любой ситуации.', CAST(4208.00 AS Decimal(7, 2)), 1, N'katushka_daiwa_19.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (7, N'Подсадная утка кряква Flambeau Gunning Mallard', N'Gunning Mallard - дань Flambeau богатой истории охоты на крякву, которую так чтят охотники на уток. Чучела изготавливают на мастер модели на основе традиционной ручной резьбы, Низкопрофильный киль, напоминающий скег лодки, в сочетании с тщательно спроектированной изогнутой нижней стороной, с утяжелителем из нержавеющей стали, за счет чего чучело плавает по воде, как живая утка.', CAST(6999.00 AS Decimal(7, 2)), 5, N'podsadnaya_utka_kryakva.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (8, N'Катушка Daiwa 21 Caldia LT 3000', N'Легкий и прочный, как болид Формулы 1. Корпус стал еще легче и прочнее, благодаря монококовой конструкции.

С момента появления первой катушки для спиннинговой ловли, ее корпус всегда состоял из двух частей: крышки корпуса и самого корпуса. После выхода на рынок цельного, МОНОКОКОВОГО корпуса в 2016г, ситуация изменилась. В конструкции МОНОКОК корпус выполняет роль несущей рамы, при этом он остается удобным и компактным. Таким образом, уже нет необходимости фиксировать крышку корпуса с помощью винта, тем самым освобождается пространство, что позволяет увеличить размер главной пары. В корпусе такой конструкции с легкостью размещается ведущая шестерня, размер которой составляет примерно 85% от всего объема корпуса. Говоря простыми словами, конструкция позволяет разместить главную пару большего размера и более прочную в корпусе того же объема.', CAST(21544.00 AS Decimal(7, 2)), 1, N'katushka_daiwa_21.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (9, N'Катушка Nautilus Butler NB3000', N'Катушки Butler представлены широкой размерной линейкой , от 500 до 4000 размера. Могут применяться во многих видах рыбной ловли. Обладают высокопрочным корпусом, алюминиевой шпулей, системой Instant Anti-Reverse System , и плавным ходом. Для предотвращения повреждения лески или плетеного шнура ролики лесоукладывателя у всех моделей покрыты нитридом титана.', CAST(2456.00 AS Decimal(7, 2)), 1, N'katushka_nautilus_butler.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (10, N'Воблер Lucky Craft Malas 507 111 peacock', N'Эту уникальную приманку можно отнести сразу к нескольким классам. Malas от Lucky Craft совмещает в себе три типа: поппер Popper , уокер Walker и кренк Crank . В первую очередь это SSR воблер. Эти поверхностные topwater приманки занимают горизонтальное положение на воде, возвышаясь над ее поверхностью почти на половину корпуса.', CAST(1156.00 AS Decimal(7, 2)), 2, N'vobler_lucky_craft.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (11, N'Воблер Savage Gear 3D suicide duck', N'Очень реалистичная поверхностная topwater приманка - имитация утенка с инновационными характеристиками.

Изготовленная на основе 3D сканирования, приманка одурачит даже самого осторожного хищника и вызовет его брутальную атаку. Твердое сверхпрочное тело ABS-пластик с мягкими износоустойчивыми лапками. Вращающиеся лапки придают приманке невероятно реалистичное поведение, оставляя после себя всплески и следы от пузырьков, тем самым вызывая интерес хищника, находящегося даже на большом расстоянии.', CAST(2169.00 AS Decimal(7, 2)), 2, N'vobler_savage_gear_3d_suicide_duck.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (12, N'Воблер Smith Camion SR цв 1', N'Воблер Smith Camion SR – плавающий Floating кренк Crank , с высокочастотной игрой. Один из столбов в знаменитой серии Camion от японской компании Smith. Эти приманки заслужено носят титул лучших плавающих Floating приманок, основным преимуществом которых принято считать единство противоположностей. Эти косопузые кренки Crank с легкостью рассекают водную гладь любых водоемов, будь это спокойное озеро или стремительный горный поток. Cпиннинг может «послать» Camion SR на 18-20 метров. Эта приманка отличается небольшой лопастью, вследствие чего воблер может работать на глубинах до полуметра.', CAST(1450.00 AS Decimal(7, 2)), 2, N'vobler_smith_camion.jpeg')
INSERT [dbo].[product] ([id], [name], [description], [price], [typeProduct], [image]) VALUES (13, N'Накидка Хольстер для засидки 2х2 сухой камыш', N'Накидка для засидки (2*2 малая).

Для дополнительной объемной маскировки охотничьих укрытий и снаряжения.

Материал: сетка с «листочками» из синтетической ткани.

Особенности:

- представляет собой сетку из шнура с ячейкой 9*9 см, которая оплетена по всей длине ячеек объемными «листочками», по периметру обшита тесьмой для прочности;

- крепление на месте осуществляется при помощи шнуров-завязок;

- отличается долговечностью, малым весом, почти не намокает, быстро сохнет;

- размер 2*2 м.', CAST(1382.00 AS Decimal(7, 2)), 4, N'nakidka_kholster_dlya.jpeg')
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [password], [name], [role], [email]) VALUES (1, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'123', 1, N'huntandfishdylo@gmail.com')
INSERT [dbo].[users] ([id], [password], [name], [role], [email]) VALUES (3, N'0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c', N'1111', 0, NULL)
INSERT [dbo].[users] ([id], [password], [name], [role], [email]) VALUES (1002, N'4c13c71d99b75dd02d386351c9b004dea7a549b5ccdcf60dc4167f3d628da730', N'Kirill', 0, NULL)
INSERT [dbo].[users] ([id], [password], [name], [role], [email]) VALUES (1003, N'b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0', N'456', 0, N'ktsyadas@bk.ru')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
