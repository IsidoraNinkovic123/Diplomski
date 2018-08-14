ALTER TABLE Nalazi_se ADD CONSTRAINT Nalazi_se_PK PRIMARY KEY CLUSTERED (
Porudzbina_ID, Stavka_menija_ID)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO