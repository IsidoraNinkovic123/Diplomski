ALTER TABLE Saradjuje ADD CONSTRAINT Saradjuje_PK PRIMARY KEY CLUSTERED (
Menadzer_MBR, Hipermarket_ID)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO