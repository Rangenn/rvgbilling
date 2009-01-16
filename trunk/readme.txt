To build project you need:

1).NET Framework 3.5
2)Nant 0.86beta, Nant Contrib (NDoc3, wiki2xhtml, htmlhelp -  for Docs generation)
3)PostgreSQL 8.3 server.
4)JDK 1.6


Steps of building:

* go to "/misc" folder
* set local path to vars in _props.bat and copy it to root folder
* set database connection params in hibernate.cfg.xml
* create DB schema described in script.sql (you can regenerate script using billing.dm2. TOAD Data Modeller required).


* run build.bat to build(result placed in "/bin"), build.doc.bat to generate documentation((result placed in "/bin/doc")
* go to "/bin"


Links:

http://nant.sourceforge.net/
http://www.pgadmin.org/