using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCTest
{
    class QCSQL
    {
        public static string SQL_QC_TestCases = @"select
CASE WHEN A.TS_SUBJECT = -2 THEN(select replace(min(AL_ABSOLUTE_PATH), 'AAA', 'XXX') + '111' from ALL_LISTS where AL_FATHER_ID not in ('-1', '0')) ELSE ALL_LISTS.AL_ABSOLUTE_PATH + '111' END As 'Hierarchy',
A.TS_NAME As 'Name',
A.TS_DESCRIPTION As 'Description',
Case When AL_ABSOLUTE_PATH like(select AL_ABSOLUTE_PATH from ALL_LISTS where AL_DESCRIPTION = '_Obsolete')+'%' Then 'Obsolete'
     When AL_ABSOLUTE_PATH like(select AL_ABSOLUTE_PATH from ALL_LISTS where AL_DESCRIPTION = 'Backup') + '%' Then 'Deprecated'
     Else 'Active' End As 'Verification Case Status',
/*replace(A.DS_STEP_NAME,'Step ','') As 'Step#', */
Case When len(DS_STEP_ORDER) = 1 Then CAST(DS_STEP_ORDER AS VARCHAR(2)) Else 'A' + CAST(DS_STEP_ORDER AS VARCHAR(2)) END AS 'Step#',
A.DS_DESCRIPTION As 'Step Action',
A.DS_EXPECTED As 'Step Expected Result',
CASE WHEN DS_ATTACHMENT = 'Y' THEN 'HasAttachment' ELSE '' END As 'Step Notes',
A.TS_TYPE as 'Verification Method',
CONVERT(VARCHAR, A.TS_TEST_ID) As 'Legacy Trace',
A.TS_RESPONSIBLE /*Test.Designer*/ As 'Assigned',
CASE WHEN A.TS_STATUS is not Null Then ALL_LISTS.AL_ITEM_ID ELSE ALL_LISTS.AL_FATHER_ID END As 'AL_FATHER_ID',
CASE WHEN A.TS_SUBJECT = -2 THEN 'Unattached' ELSE ALL_LISTS.AL_DESCRIPTION END As 'Folder_DESCRIPTION',/*for identify Unattached*/
A.TS_RESPONSIBLE,
CASE WHEN DS_ATTACHMENT = 'Y' THEN 'Y' ELSE A.TS_ATTACHMENT END As 'TS_ATTACHMENT',
A.DS_HAS_PARAMS,
A.DS_LINK_TEST,
CASE WHEN A.TS_SUBJECT = -2 THEN '0' ELSE ALL_LISTS.AL_VIEW_ORDER END As 'AL_VIEW_ORDER'
/* Case WHEN A.TS_SUBJECT=-2 THEN '0' When len(ALL_LISTS.AL_VIEW_ORDER)=1 Then CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) Else 'A'+CAST(ALL_LISTS.AL_VIEW_ORDER AS VARCHAR(255)) End As 'AL_VIEW_ORDER' */

from ALL_LISTS /*Test Plan Folder*/
right join (
select *from TEST
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
'TCF' + CONVERT(VARCHAR, AL_ITEM_ID) As 'Legacy Trace',
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
(select replace(min(AL_ABSOLUTE_PATH), 'AAA', 'XXX') from ALL_LISTS where AL_FATHER_ID not in ('-1', '0'))  As 'Hierarchy',
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
order by  'Hierarchy','Name', 'Step#'";

        public static string SQL_QC_Req = @"SELECT
A.RQ_REQ_PATH  AS 'Hierarchy',
A.RQ_REQ_ID AS 'Legacy ID',
A.RQ_REQ_NAME AS 'Title',
A.RQ_REQ_COMMENT AS 'Requirement',
'Unassigned' as 'Release Introduced',
'Active' as 'REQ Status',
A.RQ_REQ_PRIORITY As 'Priority',
A.RQ_TYPE_ID As 'Type',
/*A.RQ_ORDER_ID Requirement.Req Order ID*/
Case When len(A.RQ_ORDER_ID)=1 Then CAST(A.RQ_ORDER_ID AS VARCHAR(255)) Else 'A'+CAST(A.RQ_ORDER_ID AS VARCHAR(255)) End As 'RQ_ORDER_ID',
A.RQ_FATHER_ID As 'parentId' /*Requirement.Req Father ID*/,
B.RQ_REQ_NAME As 'parentTitle',
CASE WHEN (select count(*) from REQ where REQ.RQ_FATHER_ID=A.RQ_REQ_ID)=0 THEN 'ChildNode' ELSE 'ParentNode' END As 'FolderOrNot',
(select count(*) from REQ_COVER where REQ_COVER.RC_REQ_ID=A.RQ_REQ_ID) As 'linkTestCases',
A.RQ_REQ_STATUS,
A.RQ_REQ_PRODUCT,
A.RQ_REQ_TYPE,
A.RQ_ATTACHMENT
FROM REQ AS A
Left join REQ AS B
On A.RQ_FATHER_ID = B.RQ_REQ_ID
where A.RQ_REQ_NAME not in ('Requirements')
/*where A.RQ_TYPE_ID<>'104' and A.RQ_REQ_NAME not in ('Requirements','_RecycleBin') */
/*Where (select count(*) from REQ where REQ.RQ_FATHER_ID=A.RQ_REQ_ID)<>0 and A.RQ_TYPE_ID='1'     */
order by A.RQ_REQ_PATH,A.RQ_ORDER_ID";

        public static string SQL_QC_TCTrace = @"SELECT
REQ_COVER.RC_REQ_ID As 'QC_ReqID',
(select RQ_REQ_NAME from REQ where REQ_COVER.RC_REQ_ID=REQ.RQ_REQ_ID) As 'QC_ReqName',
REQ_COVER.RC_ENTITY_ID As 'QC_TCID',
(SELECT TEST.TS_NAME FROM TEST where REQ_COVER.RC_ENTITY_ID=TEST.TS_TEST_ID) As 'QC_TCName'
FROM  REQ_COVER
order by RC_REQ_ID,RC_ENTITY_ID";

        public static string SQL_QC_ReqTrace = @"SELECT RT_FROM_REQ_ID, RT_TO_REQ_ID,
(select RQ_REQ_NAME from REQ where REQ_TRACE.RT_FROM_REQ_ID=REQ.RQ_REQ_ID) As 'QC_UserNeed',
RQ_REQ_NAME As 'QC_Requirement'
FROM  REQ_TRACE /*Requirement Trace*/
Left join REQ
ON REQ_TRACE.RT_TO_REQ_ID=REQ.RQ_REQ_ID
order by RT_FROM_REQ_ID";
    }
}
