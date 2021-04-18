declare @i as int = 1,
			@date as date ='2017-09-16',-- convert(date, getdate()),
			@end as int;
	set @end = datediff(day, dateadd(day,1-day(@date),@date),dateadd(month,1,dateadd(day,1-day(@date),@date)));

	

	create table #myTemp(FirstName varchar(25), milknumber varchar(15));
	while @i <= @end
	begin
		declare @col as varChar(20) = convert(varchar,datepart(year,@date)) + '-' + convert(varchar,datepart(month,@date)) +'-'+ convert(varchar,@i);
		declare @colHead as varchar(25) = 'Date'+cast(@i as varchar(5))+'$'+DATENAME(M, @date)+'$'+cast(DATEPART(year,@date) as varchar(5));
		declare @sqlColl as nvarchar(250) = N'alter table #myTemp add ' + @colhead + ' NUMERIC(18,2)';
	--		print @sqlColl;
		exec (@sqlColl)

		set @i=@i+1;
	end

	select * from #myTemp
--	drop table #myTemp;


declare @k as int = 1;
declare @Columns as varchar(500);
while @k <= @end
	begin
		set @Columns = @Columns + ' Date'+cast(@i as varchar(5))+'$'+DATENAME(M, @date)+'$'+cast(DATEPART(year,@date) as varchar(5)) +', ';
		set @k=@k+1;
	end
		declare @sql as nvarchar(1000) = N'insert into #myTemp (FirstName,milknumber, '+@Columns+')
		select f.FirstName, d.milkNumber, ISNULL(sum(d.Amount),0.00) as '+@colhead+' 
		 from dbo.tbl_Deliveries d inner join dbo.tbl_Farmer_info f on d.MilkNumber = f.MilkNumber
		where convert(date, d.[DateTime]) = '''+@col+'''
		group by f.FirstName, d.MilkNumber order by d.MilkNumber';
		print @sql;
		exec(@sql);
















declare @k as int = 1;
insert into #myTemp
select f.SirName +' ' +f.FirstName + ' ' + f.LastName as Name, d.MilkNumber,
	isnull(d.amount,0.00)
from dbo.tbl_Deliveries d inner join dbo.tbl_Farmer_info f on d.MilkNumber = f.MilkNumber
		where convert(date, d.[DateTime]) >= CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@date)-1),@date),101) 
		and convert(date, d.[DateTime]) <= CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@date))),DATEADD(mm,1,@date)),101)
		group by f.SirName,f.FirstName,f.LastName, d.MilkNumber order by MilkNumber;



while @k <= @end
	begin
		set @k=@k+1;
	end
	*/
--						select * from #Temp; select * from #myTemp; select * from #aii;
--select milknumber, ISNULL(amount,0.00) as amount into #aii from #Temp where col = @colHead;

--update #myTemp set @colHead = (select amount from #aii where MilkNumber ='MK/KI/003/2016'