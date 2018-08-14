ALTER TABLE Dostava
    ADD CONSTRAINT Dostava_Porudzbina_FK FOREIGN KEY ( ID )
        REFERENCES Porudzbina ( ID );