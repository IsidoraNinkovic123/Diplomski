ALTER TABLE Komunicira
ADD CONSTRAINT Komunicira_Dobavljac_robe_FK FOREIGN KEY
(
Dobavljac_robe_ID
)
REFERENCES Dobavljac_robe
(
ID
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO
