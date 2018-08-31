CREATE PROCEDURE [dbo].[Promet](@datum date, @promet decimal output)
AS 

BEGIN

select @promet=sum(s.CENA * n.KOL)
from Porudzbina p join Nalazi_se n on p.ID = n.Porudzbina_ID 
	join Stavka_menija s on s.ID = n.Stavka_menija_ID
where cast(p.DAT as date)=@datum;

END;
