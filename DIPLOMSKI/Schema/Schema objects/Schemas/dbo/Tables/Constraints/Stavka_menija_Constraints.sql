ALTER TABLE Stavka_menija ADD CONSTRAINT Stavka_menija_PK PRIMARY KEY CLUSTERED
(ID)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO