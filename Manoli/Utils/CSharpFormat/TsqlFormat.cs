﻿// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.TsqlFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class TsqlFormat : CodeFormat
  {
    protected override string CommentRegEx => "(?:--\\s).*?(?=\\r|\\n)";

      protected override string StringRegEx => "''|'.*?'";

      public override bool CaseSensitive => false;

      protected override string Keywords => "absolute action ada add admin after aggregate alias all allocate alter and any are array as asc assertion at authorization avg backup before begin between binary bit bit_length blob boolean both breadth break browse bulk by call cascade cascaded case cast catalog char char_length character character_length check checkpoint class clob close clustered coalesce collate collation column commit completion compute connect connection constraint constraints constructor contains containstable continue convert corresponding count create cross cube current current_date current_path current_role current_time current_timestamp current_user cursor cycle data database date day dbcc deallocate dec decimal declare default deferrable deferred delete deny depth deref desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect disk distinct distributed domain double drop dummy dump dynamic each else end end-exec equals errlvl escape every except exception exec execute exists exit external extract false fetch file fillfactor first float for foreign fortran found free freetext freetexttable from full function general get global go goto grant group grouping having holdlock host hour identity identity_insert identitycol if ignore immediate in include index indicator initialize initially inner inout input insensitive insert int integer intersect interval into is isolation iterate join key kill language large last lateral leading left less level like limit lineno load local localtime localtimestamp locator lower map match max min minute modifies modify module month names national natural nchar nclob new next no nocheck nonclustered none not null nullif numeric object octet_length of off offsets old on only open opendatasource openquery openrowset openxml operation option or order ordinality out outer output over overlaps pad parameter parameters partial pascal path percent plan position postfix precision prefix preorder prepare preserve primary print prior privileges proc procedure public raiserror read reads readtext real reconfigure recursive ref references referencing relative replication restore restrict result return returns revoke right role rollback rollup routine row rowcount rowguidcol rows rule save savepoint schema scope scroll search second section select sequence session session_user set sets setuser shutdown size smallint some space specific specifictype sql sqlca sqlcode sqlerror sqlexception sqlstate sqlwarning start state statement static statistics structure substring sum system_user table temporary terminate textsize than then time timestamp timezone_hour timezone_minute to top trailing tran transaction translate translation treat trigger trim true truncate tsequal under union unique unknown unnest update updatetext upper usage use user using value values varchar variable varying view waitfor when whenever where while with without work write writetext year zone";

      protected override string Preprocessors => "@@CONNECTIONS @@CPU_BUSY @@CURSOR_ROWS @@DATEFIRST @@DBTS @@ERROR @@FETCH_STATUS @@IDENTITY @@IDLE @@IO_BUSY @@LANGID @@LANGUAGE @@LOCK_TIMEOUT @@MAX_CONNECTIONS @@MAX_PRECISION @@NESTLEVEL @@OPTIONS @@PACK_RECEIVED @@PACK_SENT @@PACKET_ERRORS @@PROCID @@REMSERVER @@ROWCOUNT @@SERVERNAME @@SERVICENAME @@SPID @@TEXTSIZE @@TIMETICKS @@TOTAL_ERRORS @@TOTAL_READ @@TOTAL_WRITE @@TRANCOUNT @@VERSION";
  }
}
