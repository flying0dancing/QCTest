SELECT
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
order by A.RQ_REQ_PATH,A.RQ_ORDER_ID