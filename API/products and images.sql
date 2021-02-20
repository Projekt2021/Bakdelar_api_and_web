USE BakdelarDB
SET IDENTITY_INSERT [dbo].[ProductImage] ON 
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (4, N'\images\products\bestick.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (5, N'\images\products\besticklåda.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (6, N'\images\products\ägghållare.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (7, N'\images\products\skopor.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (8, N'\images\products\Sil.webp', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (9, N'\images\products\Sil.webp', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (10, N'\images\products\kniv och skärbräda.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (11, N'\images\products\Kniv3.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (12, N'\images\products\knivar2.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (13, N'\images\products\knivar.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (14, N'\images\products\Koppar.jpg', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (15, N'\images\products\skillet.png', NULL)
GO
INSERT [dbo].[ProductImage] ([ProductImageID], [ImageUrl], [ProductID]) VALUES (16, N'\images\products\mortel.jpg', NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (4, N'Bestick', N'Fina bestick', 59, 0, 4)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (5, N'Bestickhållare', N'Bestickhållare i trä', 49, 0, 5)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (6, N'Ägghållare', N'Ägghållare i keramik', 39, 0, 6)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (7, N'Skopor', N'Skopor i järn', 59, 0, 7)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (8, N'Sil', N'En sil i metall', 49, 0, 8)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (9, N'Skärbräda', N'Skärbräda i trä', 99, 0, 10)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (10, N'Liten kniv', N'En liten kniv i stål', 59, 0, 11)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (11, N'Knivset', N'Ett knivset i stål', 159, 0, 12)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (12, N'Knivset fancy', N'Ett stilrent knivset', 199, 0, 13)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (13, N'Koppar', N'Coola koppar', 99, 0, 14)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (14, N'Gjutjärnspanna', N'Gammalmodig gjutjärnspanna', 99, 0, 15)
GO
INSERT [dbo].[Product] ([ID], [ProductName], [ProductDescription], [SalePrice], [CategoryID], [ProductImageID]) VALUES (15, N'Mortel', N'En mortel i trä', 39, 0, 16)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

/****** Object:  Index [IX_Product_ProductImageID]    Script Date: 2021-02-10 14:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProductImageID] ON [dbo].[Product]
(
	[ProductImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImage_ProductID]    Script Date: 2021-02-10 14:53:43 ******/
CREATE NONCLUSTERED INDEX [IX_ProductImage_ProductID] ON [dbo].[ProductImage]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [CategoryID]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [ProductImageID]
GO
ALTER TABLE [dbo].[ProductImage] ADD  DEFAULT (N'') FOR [ImageUrl]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductImage_ProductImageID] FOREIGN KEY([ProductImageID])
REFERENCES [dbo].[ProductImage] ([ProductImageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductImage_ProductImageID]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product_ProductID] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product_ProductID]
GO
USE [master]
GO
ALTER DATABASE [BakdelarDB] SET  READ_WRITE 
GO
