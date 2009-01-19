To build/run project you need:

1).NET Framework 3.5
2)Nant 0.86beta, Nant Contrib (NDoc3, Wiki2xhtml, Htmlhelp -  for Docs generation), NUnit(for launching tests)
3)PostgreSQL 8.3 server.
4)JDK 1.6


Steps of building:

* go to "/misc" folder
* set local path to vars in _props.bat and copy it to project root folder
* set database connection params in hibernate.cfg.xml
* create DB schema described in script.sql (you can regenerate script using billing.dm2. TOAD Data Modeller required).


* run build.bat to build(result placed in "/bin"), build.doc.bat to generate documentation((result placed in "/bin/doc").
"/out" will contain zip-archive with source code and binaries.
* go to "/bin"

Steps to debug:
* fill DB with "misc/RVG fill DB UTF8.sql" script (to reproduce testing data)
* run program
* hint: if you get NpgsqlException, try to copy npgsql.dll into folder, which contains exe file (when opening solution and debugging in Visual Studio)


Links:

http://code.google.com/p/rvgbilling/issues/list - Our BugTracker! known bugs placed here.
http://nant.sourceforge.net/
http://www.pgadmin.org/