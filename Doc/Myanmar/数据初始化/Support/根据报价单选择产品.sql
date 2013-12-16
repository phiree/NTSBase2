select c.fnumber,b.fauxqty,s.fname

 from porfq a
inner join porfqentry b
on a.finterid=b.finterid
and a.fbillno in (
 'AQ000052'
,'AQ000053'
,'AQ000050'
,'AQ000059'
,'AQ000058'
,'AQ000057'
,'AQ000045'
,'AQ000048'
,'AQ000049'
)
inner join t_ICItem c
on c.fitemid=b.fitemid
left join t_supplier s
on  left(right(c.fnumber,10),5)=s.fnumber
order by b.fauxqty

-- 
Create table BarCodeQtyFromSylvia
(

)

select * from porfqentry
select * from t_tabledescription where fdescription like '%π©”¶…Ã%'

select * from t_Supplier