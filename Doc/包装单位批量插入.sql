/*

select item.fnumber,item.fitemid,item.funitid,item.*,'---',pack.* from t_icitem item
left join ExpItemPacking pack

on item.fitemid=pack.fitemid
where pack.fid is null
and fnumber='05.001.0008600009'


*/
declare material_cursor cursor for
select item.fitemid,item.funitid from t_icitem item
left join ExpItemPacking pack

on item.fitemid=pack.fitemid
where pack.fid is null

declare @fitemid int
declare @FUnitID int
DECLARE @q INT
SET @q = 1;

declare @init_fid int
select @init_fid=max(fid) from  ExpItemPacking

open  material_cursor
fetch Next from material_cursor
into @fitemid,@FUnitID
while @@fetch_status=0
begin

    INSERT INTO ExpItemPacking (fid,fbillno,fclasstypeid,fitemid) 
    VALUES (@init_fid+@q,RIGHT('0000000'+CONVERT(varchar(10),@q+4),8) ,1007191,@fitemid);
    
    insert into ExpItemPackingEntry 
(fclasstypeid,fid,findex,fnumber,fname,fpackingunit,fpackingmode,fgrossweight,fnetweight,flength,fwidth,fheight,fcubage,fismainpacking,funit)
values
(0,@init_fid+@q,'1','01','Ïä','CARTON','1.0000000000','10.0000000000','9.0000000000','100.0000000000','50.0000000000','30.0000000000','25.0000000000',0,@FUnitID)

  insert into ExpItemPackingEntry 
(fclasstypeid,fid,findex,fnumber,fname,fpackingunit,fpackingmode,fgrossweight,fnetweight,flength,fwidth,fheight,fcubage,fismainpacking,funit)
values
(0,@init_fid+@q,'1','02','°ü','BAG','1.0000000000','10.0000000000','9.0000000000','100.0000000000','50.0000000000','30.0000000000','25.0000000000',0,@FUnitID)


  insert into ExpItemPackingEntry 
(fclasstypeid,fid,findex,fnumber,fname,fpackingunit,fpackingmode,fgrossweight,fnetweight,flength,fwidth,fheight,fcubage,fismainpacking,funit)
values
(0,@init_fid+@q,'1','03','ÆäËü','PACKAGE','1.0000000000','10.0000000000','9.0000000000','100.0000000000','50.0000000000','30.0000000000','25.0000000000',0,@FUnitID)
 

    SET @q = @q + 1;  
    fetch next from material_cursor
    into @fitemid,@FUnitID
end

close  material_cursor
deallocate  material_cursor