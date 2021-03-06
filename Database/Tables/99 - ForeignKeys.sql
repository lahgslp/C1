/****** Object:  ForeignKey [FK_CustomerContact_Customer]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[CustomerContact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerContact_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerContact] CHECK CONSTRAINT [FK_CustomerContact_Customer]
GO
/****** Object:  ForeignKey [FK_PipeSpecification_PipeDiameterType]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[PipeSpecification]  WITH CHECK ADD  CONSTRAINT [FK_PipeSpecification_PipeDiameterType] FOREIGN KEY([PipeDiameterTypeID])
REFERENCES [dbo].[PipeDiameterType] ([PipeDiameterTypeID])
GO
ALTER TABLE [dbo].[PipeSpecification] CHECK CONSTRAINT [FK_PipeSpecification_PipeDiameterType]
GO
/****** Object:  ForeignKey [FK_Quotation_Customer]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Customer]
GO
/****** Object:  ForeignKey [FK_Quotation_CustomerContact]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_CustomerContact] FOREIGN KEY([CustomerContactID])
REFERENCES [dbo].[CustomerContact] ([CustomerContactID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_CustomerContact]
GO
/****** Object:  ForeignKey [FK_Quotation_QuotationStatusType]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_QuotationStatusType] FOREIGN KEY([QuotationStatusTypeID])
REFERENCES [dbo].[QuotationStatusType] ([QuotationStatustypeID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_QuotationStatusType]
GO
/****** Object:  ForeignKey [FK_QuotationAttachment_Quotation]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[QuotationAttachment]  WITH CHECK ADD  CONSTRAINT [FK_QuotationAttachment_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([QuotationID])
GO
ALTER TABLE [dbo].[QuotationAttachment] CHECK CONSTRAINT [FK_QuotationAttachment_Quotation]
GO
/****** Object:  ForeignKey [FK_QuotationSection_Quotation]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[QuotationSection]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSection_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([QuotationID])
GO
ALTER TABLE [dbo].[QuotationSection] CHECK CONSTRAINT [FK_QuotationSection_Quotation]
GO
/****** Object:  ForeignKey [FK_QuotationSection_SectionType]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[QuotationSection]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSection_SectionType] FOREIGN KEY([SectionTypeID])
REFERENCES [dbo].[SectionType] ([SectionTypeID])
GO
ALTER TABLE [dbo].[QuotationSection] CHECK CONSTRAINT [FK_QuotationSection_SectionType]
GO
/****** Object:  ForeignKey [FK_QuotationSectionDetail_QuotationSection]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[QuotationSectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSectionDetail_QuotationSection] FOREIGN KEY([QuotationSectionID])
REFERENCES [dbo].[QuotationSection] ([QuotationSectionID])
GO
ALTER TABLE [dbo].[QuotationSectionDetail] CHECK CONSTRAINT [FK_QuotationSectionDetail_QuotationSection]
GO
/****** Object:  ForeignKey [FK_QuotationSectionDetail_UnitType]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[QuotationSectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSectionDetail_UnitType] FOREIGN KEY([UnitTypeID])
REFERENCES [dbo].[UnitType] ([UnitTypeID])
GO
ALTER TABLE [dbo].[QuotationSectionDetail] CHECK CONSTRAINT [FK_QuotationSectionDetail_UnitType]
GO
/****** Object:  ForeignKey [FK_UserCompanyPreferences_Company]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[UserCompanyPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserCompanyPreferences_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[UserCompanyPreferences] CHECK CONSTRAINT [FK_UserCompanyPreferences_Company]
GO
/****** Object:  ForeignKey [FK_UserCompanyPreferences_Users]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[UserCompanyPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserCompanyPreferences_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserCompanyPreferences] CHECK CONSTRAINT [FK_UserCompanyPreferences_Users]
GO
/****** Object:  ForeignKey [FK_UserPreferences_Users]    Script Date: 12/06/2010 23:13:25 ******/
ALTER TABLE [dbo].[UserPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserPreferences_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPreferences] CHECK CONSTRAINT [FK_UserPreferences_Users]
GO
