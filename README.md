# badgr-csharp-api-wrapper

Badgr is a open source platform that is designed to help users issue and consume badges. This is a c# wrapper that will help you use badgrs api in a windows environment. 

Some notes 
* Currently this endpoint is broken POST - /v1/issuer/issuers/{slug}/staff (Add or remove a user from a role on an issuer. Limited to Owner users only)
* Null values on update will clear out data
* Issuer field and Badge class field will sometimes return a slug and sometimes a url with the id at the end.
* Not sure what user email update api will update. No errors but nothing would update
* Urls require http or https included
* I did not build out the backpack api calls. I build this tool to help automate some of the administrative tasks between Badgr and our      system. 
