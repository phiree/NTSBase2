select * from product where modelnumber like '%\\%'
or modelnumber like '%/%'
or modelnumber like '%<%'
or modelnumber like '%>%'
or modelnumber like '%?%'
or modelnumber like '%*%'
or modelnumber like '%"%'
or modelnumber like '%:%'
or modelnumber like '%|%'

update product set modelnumber=replace(
					replace(
					replace(
 replace(
					replace(
					replace(
 replace(
					replace(
					replace(
						modelnumber,'\\','$')

								   ,'/','$')
								   ,'<','$') 
									 ,'>','$')
									 ,'?','$')
									 ,'*','$')
									 ,'"','$')
									 ,':','$')
									 ,'|','$')