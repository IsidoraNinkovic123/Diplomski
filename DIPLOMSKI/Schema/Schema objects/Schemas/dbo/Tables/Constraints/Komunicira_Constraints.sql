ALTER TABLE Komunicira ADD CONSTRAINT Komunicira_PK PRIMARY KEY CLUSTERED (
Menadzer_MBR, Dobavljac_robe_ID)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO