CREATE
  TABLE Dobavljac_robe
  (
    ID      INTEGER NOT NULL IDENTITY(1,1) ,
    NAZ     VARCHAR (50) NOT NULL ,
    TEL     VARCHAR (50) NOT NULL ,
    VR_ROBE VARCHAR (50) NOT NULL
  )
  ON "default"
GO
