﻿// Decompiled with JetBrains decompiler
// Type: Manoli.Utils.CSharpFormat.FoxProFormat
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

namespace Manoli.Utils.CSharpFormat
{
  public class FoxProFormat : CodeFormat
  {
    public override bool CaseSensitive
    {
      get
      {
        return false;
      }
    }

    protected override string CommentRegEx
    {
      get
      {
        return "(?:\\*).*?(?=\\r|\\n)";
      }
    }

    protected override string StringRegEx
    {
      get
      {
        return "@?\"\"|@?\".*?(?!\\\\).\"|''|'.*?(?!\\\\).'";
      }
    }

    protected override string Keywords
    {
      get
      {
        return "Define Do DoDefault DoEvents\r\nElse Endcase Enddefine Enddo Endfor Endfunc Endif Endprintjob Endproc Endscan Endtext EndTry Endwith Exit\r\nFinally For Function\r\nHidden\r\nIf\r\nLocal Lparameter Lparameters\r\nNext\r\nOtherwise\r\nParameters Printjob Procedure Protected Public\r\nScan\r\nText Then Throw Try\r\nWhile With\r\nActivate Add Alter Alternate Ansi App Append Array Assert Asserts Assist Autoincerror Autosave Average \r\nBar Begin Bell Blank Blocksize Border Box Browse Browseime Brstatus Build\r\nCalculate Call Cancel Carry Catch Cd Century Change Chdir Class Classlib Clear Clock Close Collate Color Compatible Compile Confirm Connection Connections Console Continue Copy Count Coverage Cpcompile Cpdialog Create Currency Cursor Cursor\r\nDatabase Datasession Date Deactivate Debug Debugout Decimals Declare Default Define Delete Deleted Delimiters Development Device Dimension Dir Directory Display Dll Dlls Dock Doevents Dohistory Drop \r\nEcho Edit Eject End Enginebehavior Erase Error Escape Eventlist Events Eventtracking Exact Exclusive Exe Export Extended External\r\nFdow Fields File Files Filter Finally Find Fixed Flush Form Format Free From Fullpath Function Fweek\r\nGather General Get Getexpr Gets Go Goto \r\nHeadings Help Hide Hours \r\nId Import Index Indexes Input Insert Intensity \r\nJoin \r\nKey Keyboard Keycomp \r\nLabel Library List Load Local Locate Lock Logerrors Loop Lparameters \r\nMackey Macro Macros  Margin Mark Md Memo Memory Memowidth Menu Menus Message Mkdir Modify Mouse Move Mtdll Multilocks \r\nNear Nocptrans Note Notify Null Nulldisplay \r\nObject Objects Odometer Of Off Oleobject On Open Optimize Order\r\nPack Pad Page Palette Parameters Path Pdsetup Play Point Pop Popup Popups Printer Private Procedure Procedures Project Public Push\r\nQuery Quit\r\nRd Read Readborder Readerror Recall Refresh Reindex Relation Release Remove Rename Replace Report Reprocess Resource Restore Resume Retry Return Rmdir Rollback Run\r\nSafety Save Scatter Scheme Screen Scroll Seconds Seek Select Selection Separator Set Show Shutdown Size Skip Skip Sort Space Sql Status Step Store Strictdate Structure Sum Suspend Sysformats Sysmenu\r\nTable Tables Tablevalidate Tag Talk Textmerge This Throw To Topic Total Transaction Trbetween Trigger Try Type Typeahead\r\nUdfparms Unique Unlock  UpdateUse\r\nValidate View Views\r\nWait Window Windows Windows\r\nAbs Aclass Acopy Acos Adatabases Adbobjects Addbs Addproperty Adel Adir Adlls Adockstate Aelement Aerror Aevents Afields Afont Agetclass Agetfileversion Ains Ainstance Alanguage Alen Alias Alines Alltrim Amembers Amouseobj Anetresources Aprinters Aprocinfo Asc Ascan Aselobj Asessions Asin Asort Astackinfo Asubscript At At_c Ataginfo Atan Atc Atcc Atcline Atline Atn2 Aused Avcxclasses\r\nBar Barcount Barprompt Between Bindevent Bintoc Bitand Bitclear Bitlshift Bitnot Bitor Bitrshift Bitset Bittest Bitxor Bof \r\nCandidate Capslock Cdow Cdx Ceiling Chr Chrsaw Chrtran Chrtranc Cmonth Cntbar Cntpad Col Com Comarray Comclassinfo Compobj Comprop Comreturnerror Cos Cpconvert Cpcurrent Cpdbf Createbinary Createobject Createobjectex Createoffline Ctobin Ctod Ctot Curdir Cursorgetprop Cursorsetprop Cursortoxml Curval\r\nDate Datetime Day Dbc Dbf Dbgetprop Dbsetprop Dbused Ddeaborttrans Ddeadvise Ddeenabled Ddeexecute Ddeinitiate Ddelasterror Ddepoke Dderequest Ddesetoption Ddesetservice Ddesettopic Ddeterminate Declare Defaultext Deleted Descending Difference Directory Diskspace Displaypath Dmy Dodefault Dow Drivetype Dropoffline Dtoc Dtor Dtos Dtot\r\nEditsource Empty Eof Error Evaluate Eventhandler Evl Execscript Exp \r\nFchsize Fclose Fcount Fcreate Fdate Feof Ferror Fflush Fgets Field File Filetostr Filter Fklabel Fkmax Fldlist Flock Floor Fontmetric Fopen For Forceext Forcepath Found Fputs Fread Fseek Fsize Ftime Fullpath Function Command Fv Fwrite \r\nGetbar Getcolor Getcp Getdir Getenv Getfile Getfldstate Getfont Getinterface Getnextmodified Getobject Getpad Getpem Getpict Getprinter Getwordcount Getwordnum Getcursoradapter Gomonth \r\nHeader Home Hour\r\nIdxcollate Iif Imestatus Indbc Indexseek Inkey Inlist Inputbox Insmode Int Isalpha Isblank Iscolor Isdigit Isexclusive Isflocked Isleadbyte Islower Ismouse Isnull Isreadonly Isrlocked Isupper \r\nJustdrive Justext Justfname Justpath Juststem \r\nKey Keymatch \r\nLastkey Left Leftc Len Lenc Like Likec Lineno Loadpicture Locfile Lock Log Log10 Lookup Lower Ltrim Lupdate \r\nMax Mcol Mdown Mdx Mdy Memlines Memory Menu Message Messagebox Min Minute Mline Mod Month Mrkbar Mrkpad Mrow Mton Mwindow \r\nNdx Newobject Normalize Ntom Numlock Nvl \r\nObjnum Objtoclient Objvar Occurs Oemtoansi Oldval On Order Os \r\nPad Padl Padr Padc Parameters Payment Pcol Pcount Pemstatus Pi Popup Primary Printstatus Prmbar Prmpad Program Prompt Proper Prow Prtinfo Putfile Pv\r\nQuarter \r\nRaiseevent Rand Rat Ratc Ratline Rdlevel Readkey Reccount Recno Recsize Refresh Relation Replicate Requery Rgb Rgbscheme Right Rightc Rlock Round Row Rtod Rtrim \r\nSavepicture Scheme Scols Sec Seconds Seek Select Set Setfldstate Sign Sin Skpbar Skppad Soundex Space Sqlcancel Sqlcolumns Sqlcommit Sqlconnect Sqldisconnect Sqlexec Sqlgetprop Sqlmoreresults Sqlprepare Sqlrollback Sqlsetprop Sqlstringconnect Sqltables Sqrt Srows Str Strconv Strextract Strtofile Strtran Stuff Stuffc Substr Substrc Syss Overview Sysmetric \r\nTablerevert Tableupdate Tag Tagcount Tagno Tan Target Textmerge Time Transform Trim Ttoc Ttod Txnlevel Txtwidth Type \r\nUnbindevents Unique Updated Upper Used \r\nVal Varread Vartype Version \r\nWborder Wchild Wcols Wdockable Week Wexist Wfont Wlast Wlcol Wlrow Wmaximum Wminimum Wontop Woutput Wparent Wread Wrows Wtitle Wvisible \r\nXmltocursor Xmlupdategram \r\nYear_Alignment _Asciicols _Asciirows _Assist _Beautify _Box _Browser _Builder _Calcmem _Calcvalue _Cliptext _Converter _Coverage _Coverage _Curobj _Dblclick _Diarydate _Dos _Foxdoc _Foxgraph _Gallery _Gengraph _Genhtml _Genmenu _Genpd _Genscrn _Genxtab _Getexpr _Include _Indent _Lmargin _Mac _Mbr_appnd _Mbr_cpart _Mbr_delet _Mbr_font _Mbr_goto _Mbr_grid _Mbr_link _Mbr_mode _Mbr_mvfld _Mbr_mvprt _Mbr_seek _Mbr_sp100 _Mbr_sp200 _Mbr_szfld _Mbrowse _Mda_appnd _Mda_avg _Mda_brow _Mda_calc _Mda_copy _Mda_count _Mda_label _Mda_pack _Mda_reprt _Mda_rindx _Mda_setup _Mda_sort _Mda_sp100 _Mda_sp200 _Mda_sp300 _Mda_sum _Mda_total _Mdata _Mdiary _Med_clear _Med_copy _Med_cut _Med_cvtst _Med_find _Med_finda _Med_goto _Med_insob _Med_link _Med_obj _Med_paste _Med_pref _Med_pstlk _Med_redo _Med_repl _Med_repla _Med_slcta _Med_sp100 _Med_sp200 _Med_sp300 _Med_sp400 _Med_sp500 _Med_undo _Medit _Mfi_clall _Mfi_close _Mfi_export _Mfi_import _Mfi_new _Mfi_open _Mfi_pgset _Mfi_prevu _Mfi_print _Mfi_quit _Mfi_revrt _Mfi_savas _Mfi_save _Mfi_send _Mfi_setup _Mfi_sp100 _Mfi_sp200 _Mfi_sp300 _Mfi_sp400 _Mfile _Mfiler _Mfirst _Mlabel _Mlast _Mline _Mmacro _Mmbldr _Mpr_beaut _Mpr_cancl _Mpr_compl _Mpr_do _Mpr_docum _Mpr_formwz _Mpr_gener _Mpr_graph _Mpr_resum _Mpr_sp100 _Mpr_sp200 _Mpr_sp300 _Mpr_suspend _Mprog _Mproj _Mrc_appnd _Mrc_chnge _Mrc_cont _Mrc_delet _Mrc_goto _Mrc_locat _Mrc_recal _Mrc_repl _Mrc_seek _Mrc_sp100 _Mrc_sp200 _Mrecord _Mreport _Mrqbe _Mscreen _Msm_data _Msm_edit _Msm_file _Msm_format _Msm_prog _Msm_recrd _Msm_systm _Msm_text _Msm_tools _Msm_view _Msm_windo _Mst_about _Mst_ascii _Mst_calcu _Mst_captr _Mst_dbase _Mst_diary _Mst_filer _Mst_help _Mst_hphow _Mst_hpsch _Mst_macro _Mst_office _Mst_puzzl _Mst_sp100 _Mst_sp200 _Mst_sp300 _Mst_specl _Msysmenu _Msystem _Mtable _Mtb_appnd _Mtb_cpart _Mtb_delet _Mtb_delrc _Mtb_goto _Mtb_link _Mtb_mvfld _Mtb_mvprt _Mtb_props _Mtb_recal _Mtb_sp100 _Mtb_sp200 _Mtb_sp300 _Mtb_sp400 _Mtb_szfld _Mwi_arran _Mwi_clear _Mwi_cmd _Mwi_color _Mwi_debug _Mwi_hide _Mwi_hidea _Mwi_min _Mwi_move _Mwi_rotat _Mwi_showa _Mwi_size _Mwi_sp100 _Mwi_sp200 _Mwi_toolb _Mwi_trace _Mwi_view _Mwi_zoom _Mwindow _Mwizards _Mwz_all _Mwz_form _Mwz_foxdoc _Mwz_import _Mwz_label _Mwz_mail _Mwz_pivot _Mwz_query _Mwz_reprt _Mwz_setup _Mwz_table _Mwz_upsizing _Netware _Oracle _Padvance _Pageno _Pbpage _Pcolno _Pcopies _Pdparms _Pdriver _Pdsetup _Pecode _Peject _Pepage _Pform _Plength _Plineno _Ploffset _Ppitch _Pquality _Pretext _Pscode _Pspacing _Pwait _Rmargin _Runactivedoc _Samples _Screen _Shell _Spellchk _Sqlserver _Startup _Tabs _Tally _Text _Throttle _Transport _Triggerlevel _Unix _WebDevOnly _WebMenu _WebMsftHomePage _WebVFPHomePage _WebVfpOnlineSupport _Windows _Wizard _Wrap _scctext _vfp\r\n";
      }
    }

    protected override string Preprocessors
    {
      get
      {
        return "#if #else #endif #define #undefine #warning #error #line #region #endregion #pragma";
      }
    }
  }
}
