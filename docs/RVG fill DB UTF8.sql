--
-- PostgreSQL database dump
--

-- Started on 2008-12-17 15:23:08

SET client_encoding = 'UTF8';
SET standard_conforming_strings = off;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET escape_string_warning = off;

SET search_path = public, pg_catalog;

delete from prices;

delete from bills;

delete from calls;

delete from numbers;

delete from rates;

delete from abonents;

delete from users;
--
-- TOC entry 1809 (class 0 OID 0)
-- Dependencies: 1485
-- Name: abonents_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('abonents_id_seq', 7, true);


--
-- TOC entry 1810 (class 0 OID 0)
-- Dependencies: 1497
-- Name: bills_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('bills_id_seq', 1, true);


--
-- TOC entry 1811 (class 0 OID 0)
-- Dependencies: 1491
-- Name: calls_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('calls_id_seq', 7, true);


--
-- TOC entry 1812 (class 0 OID 0)
-- Dependencies: 1495
-- Name: numbers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('numbers_id_seq', 11, true);


--
-- TOC entry 1813 (class 0 OID 0)
-- Dependencies: 1487
-- Name: prices_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('prices_id_seq', 7, true);


--
-- TOC entry 1814 (class 0 OID 0)
-- Dependencies: 1489
-- Name: rates_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('rates_id_seq', 4, true);


--
-- TOC entry 1815 (class 0 OID 0)
-- Dependencies: 1493
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('users_id_seq', 1, false);


--
-- TOC entry 1800 (class 0 OID 106604)
-- Dependencies: 1490
-- Data for Name: rates; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO rates (id, name) VALUES (1, 'Экономный');
INSERT INTO rates (id, name) VALUES (2, 'Обычный');
INSERT INTO rates (id, name) VALUES (3, 'Все включено');
--
-- TOC entry 1806 (class 0 OID 106646)
-- Dependencies: 1500
-- Data for Name: private_abonents; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO private_abonents (id, address, phone, creation_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date) VALUES (1, 'г.Воронеж', '223344', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'ivanov@mail.ru', 'Иванов', 'Иван', 'Иванович', '2004222222', '2008-12-15 00:00:00', 'выдан РОВД г.Иваново', '1978-10-15 00:00:00');
INSERT INTO private_abonents (id, address, phone, creation_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date, dissolved) VALUES (2, 'г.Воронеж', '556677', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'PupkinVasya@hotmail.com', 'Пупкин', 'Василий', 'Петрович', '2005222222', '2008-12-15 00:00:00', 'выдан РОВД г.Семилуки', '1980-08-15 00:00:00', true);
INSERT INTO private_abonents (id, address, phone, creation_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date) VALUES (3, 'г.Воронеж', '365365', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'vaa@gmail.com', 'Вассерман', 'Анатолий', 'Анатольевич', '2006123123', '2008-12-15 00:00:00', 'выдан РОВД г.Москвы', '1968-12-03 00:00:00');

--
-- TOC entry 1805 (class 0 OID 106642)
-- Dependencies: 1499
-- Data for Name: corporate_abonents; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO corporate_abonents (id, address, phone, creation_time, last_pay_date, mail_address, corporate_name, "inn") VALUES (4, 'г.Воронеж', '321321', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'umbrella@corp.net', 'Umbrella corp.','7729425477');
INSERT INTO corporate_abonents (id, address, phone, creation_time, last_pay_date, mail_address, corporate_name, "inn") VALUES (5, 'г.Воронеж', '765765', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'ibm@ibm.com', 'IBM','7756230000');
INSERT INTO corporate_abonents (id, address, phone, creation_time, last_pay_date, mail_address, corporate_name, "inn") VALUES (6, 'г.Воронеж', '777777', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'mash@oskol.ru', 'ООО ОсколГорМаш','7782341234');


--
-- TOC entry 1803 (class 0 OID 106628)
-- Dependencies: 1496
-- Data for Name: numbers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (1, 1, 1, '9203334455');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (2, 2, 1, '9051231231');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (3, 3, 2, '9607867861');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (4, 4, 2, '9103222231');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (5, 5, 3, '9204133141');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (6, 1, 3, '9045556667');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (7, 2, 1, '9055099055');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (8, 3, 2, '9600690696');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (9, 4, 3, '9103455667');
INSERT INTO numbers (id, abonent_id, rate_id, number) VALUES (10, 1, 1, '9204122211');



--
-- TOC entry 1799 (class 0 OID 106596)
-- Dependencies: 1488
-- Data for Name: prices; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (4, 1, 1.000000, '920');
INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (5, 1, 1.000000, '910');
INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (6, 2, 2.000000, '920');
INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (1, 2, 2.000000, '910');
INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (2, 3, 5.000000, '920');
INSERT INTO prices (id, rate_id, cost_per_minute, mask) VALUES (3, 3, 5.000000, '910');


--
-- TOC entry 1801 (class 0 OID 106612)
-- Dependencies: 1492
-- Data for Name: calls; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (1, '9209209202', '2008-12-15 00:00:00', 1, 60);
INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (2, '9101112223', '2008-12-15 00:00:00', 2, 61);
INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (3, '9209209202', '2008-12-15 00:00:00', 3, 120);
INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (4, '9101112223', '2008-12-15 00:00:00', 4, 1);
INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (5, '9209209202', '2008-12-15 00:00:00', 1, 60);
INSERT INTO calls (id, calling_number, creation_time, number_id, duration) VALUES (6, '9031112223', '2008-12-15 00:00:00', 5, 60);

