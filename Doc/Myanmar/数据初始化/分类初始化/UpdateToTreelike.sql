update a	
 set a.jparentid=b.jid
 from  tbasicsort a 
	inner join tbasicsort b
 on  '0'+left(a.jclasscode,2) =b.jclasscode
 and  len(a.jclasscode)>3  and a.jid not in (1,2,3)





