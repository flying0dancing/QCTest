select
CASE WHEN A.TS_SUBJECT=-2 THEN (select replace(min(AL_ABSOLUTE_PATH),'AAA','XXX')+'111' from ALL_LISTS where AL_FATHER_ID not in ('-1', '0') ) ELSE ALL_LISTS.AL_ABSOLUTE_PATH+'111' END   As 'Hierarchy',
A.TS_NAME As 'Name',
A.TS_DESCRIPTION As 'Description',
Case When AL_ABSOLUTE_PATH like (select AL_ABSOLUTE_PATH from ALL_LISTS where AL_DESCRIPTION ='_Obsolete')+'%' Then 'Obsolete'
     When AL_ABSOLUTE_PATH like (select AL_ABSOLUTE_PATH from ALL_LISTS where AL_DESCRIPTION ='Backup')+'%' Then 'Deprecated'
     Else 'Active' End As 'Verification Case Status',
/*replace(A.DS_STEP_NAME,'Step ','') As 'Step#', */
Case When len(DS_STEP_ORDER)=1 Then CAST(DS_STEP_ORDER AS VARCHAR(2)) Else 'A'+CAST(DS_STEP_ORDER AS VARCHAR(2)) END AS 'Step#',
A.DS_DESCRIPTION As 'Step Action',
A.DS_EXPECTED As 'Step Expected Result',
CASE WHEN DS_ATTACHMENT='Y' THEN 'HasAttachment' ELSE '' END As 'Step Notes',
A.TS_TYPE as 'Verification Method',
CONVERT(VARCHAR, A.TS_TEST_ID) As 'Legacy Trace',
A.TS_RESPONSIBLE /*Test.Designer*/ As 'Assigned',
CASE WHEN A.TS_STATUS is not Null Then ALL_LISTS.AL_ITEM_ID ELSE ALL_LISTS.AL_FATHER_ID END As 'AL_FATHER_ID',
CASE WHEN A.TS_SUBJECT=-2 THEN 'Unattached' ELSE ALL_LISTS.AL_DESCRIPTION END As 'Folder_DESCRIPTION',/*for identify Unattached*/
A.TS_RESPONSIBLE,
CASE WHEN DS_ATTACHMENT='Y' THEN 'Y' ELSE A.TS_ATTACHMENT END As 'TS_ATTACHMENT',
A.DS_HAS_PARAMS,
A.DS_LINK_TEST,
CASE WHEN A.TS_SUBJECT=-2 THEN '0' ELSE ALL_LISTS.AL_VIEW_ORDER END As 'AL_VIEW_ORDER'
/* Case WHEN A.TS_SUBJECT=-2 THEN '0' When len(ALL_LISTS.AL_VIEW_ORDER)=1 Then CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) Else 'A'+CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) End As 'AL_VIEW_ORDER' */

from ALL_LISTS /*Test Plan Folder*/
right join (
select * from  TEST
left join DESSTEPS
ON TEST.TS_TEST_ID = DESSTEPS.DS_TEST_ID
) AS A
on ALL_LISTS.AL_ITEM_ID = A.TS_SUBJECT
where TS_NAME is not null

union all
select
ALL_LISTS.AL_ABSOLUTE_PATH As 'Hierarchy',
ALL_LISTS.AL_DESCRIPTION As 'Name',
'' As 'Description',
'' As 'Verification Case Status',
''  As 'Step#',
'' As 'Step Action',
'' As 'Step Expected Result',
'' As 'Step Notes',
'Unassigned' as 'Verification Method',
'TCF'+CONVERT(VARCHAR, AL_ITEM_ID) As 'Legacy Trace',
'' As 'Assigned',
ALL_LISTS.AL_FATHER_ID,
ALL_LISTS.AL_DESCRIPTION As 'Folder_DESCRIPTION',

'' As 'TS_RESPONSIBLE',
'' As 'TS_ATTACHMENT',
'' As 'DS_HAS_PARAMS',
'' As 'DS_LINK_TEST',
AL_VIEW_ORDER As 'AL_VIEW_ORDER'
/*Case When len(AL_VIEW_ORDER)=1 Then CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) Else 'A'+CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) End As 'AL_VIEW_ORDER'*/
from ALL_LISTS
where AL_FATHER_ID not in ('-1', '0')


union
select
(select replace(min(AL_ABSOLUTE_PATH),'AAA','XXX') from ALL_LISTS where AL_FATHER_ID not in ('-1', '0') )  As 'Hierarchy',
'Unattached' As 'Name',
'' As 'Description',
'' As 'Verification Case Status',
''  As 'Step#',
'' As 'Step Action',
'' As 'Step Expected Result',
'' As 'Step Notes',
'Unassigned' As 'Verification Method',
'TCF-1' As 'Legacy Trace',
'' As 'Assigned',
'' As 'AL_FATHER_ID',
'Unattached' As 'Folder_DESCRIPTION',
''  As 'TS_RESPONSIBLE',
'' As 'TS_ATTACHMENT',
'' As 'DS_HAS_PARAMS',
'' As 'DS_LINK_TEST',
/*'0' As 'AL_VIEW_ORDER',*/
'0' As 'AL_VIEW_ORDER'
order by  'Hierarchy','Name', 'Step#'