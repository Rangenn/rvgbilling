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

INSERT INTO private_abonents (id, address, phone, reg_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date) VALUES (1, 'г.Воронеж', '223344', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'ivanov@mail.ru', 'Иванов', 'Иван', 'Иванович', '2004222222', '2008-12-15 00:00:00', 'выдан РОВД г.Иваново', '1978-10-15 00:00:00');
INSERT INTO private_abonents (id, address, phone, reg_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date) VALUES (2, 'г.Воронеж', '556677', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'PupkinVasya@hotmail.com', 'Пупкин', 'Василий', 'Петрович', '2005222222', '2008-12-15 00:00:00', 'выдан РОВД г.Семилуки', '1980-08-15 00:00:00');
INSERT INTO private_abonents (id, address, phone, reg_time, last_pay_date, mail_address, surname, name, patronymic, passport_series, passport_date, passport_department, birth_date) VALUES (3, 'г.Воронеж', '365365', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'vaa@gmail.com', 'Вассерман', 'Анатолий', 'Анатольевич', '2006123123', '2008-12-15 00:00:00', 'выдан РОВД г.Москвы', '1968-12-03 00:00:00');

--
-- TOC entry 1805 (class 0 OID 106642)
-- Dependencies: 1499
-- Data for Name: corporate_abonents; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO corporate_abonents (id, address, phone, reg_time, last_pay_date, mail_address, corporate_name) VALUES (4, 'г.Воронеж', '321321', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'umbrella@corp.net', 'Umbrella corp.');
INSERT INTO corporate_abonents (id, address, phone, reg_time, last_pay_date, mail_address, corporate_name) VALUES (5, 'г.Воронеж', '765765', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'ibm@ibm.com', 'IBM');
INSERT INTO corporate_abonents (id, address, phone, reg_time, last_pay_date, mail_address, corporate_name) VALUES (6, 'г.Воронеж', '777777', '2008-12-15 00:00:00', '2008-12-15 00:00:00', 'mash@oskol.ru', 'ООО ОсколГорМаш');


--
-- TOC entry 1803 (class 0 OID 106628)
-- Dependencies: 1496
-- Data for Name: numbers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (1, 1, 1, '9203334455', 0);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (2, 2, 1, '9051231231', 0);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (3, 3, 2, '9607867861', 0);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (4, 4, 2, '9103222231', 0);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (5, 5, 3, '9204133141', 0);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (6, 1, 3, '9045556667', 1);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (7, 2, 1, '9055099055', 1);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (8, 3, 2, '9600690696', 1);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (9, 4, 3, '9103455667', 1);
INSERT INTO numbers (id, abonent_id, rate_id, number, idx) VALUES (10, 1, 1, '9204122211', 2);



--
-- TOC entry 1799 (class 0 OID 106596)
-- Dependencies: 1488
-- Data for Name: prices; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (4, 1, 1.000000, '920', NULL);
INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (5, 1, 1.000000, '910', NULL);
INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (6, 2, 2.000000, '920', NULL);
INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (1, 2, 2.000000, '910', NULL);
INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (2, 3, 5.000000, '920', NULL);
INSERT INTO prices (id, rate_id, cost_per_minute, mask, idx) VALUES (3, 3, 5.000000, '910', NULL);


--
-- TOC entry 1801 (class 0 OID 106612)
-- Dependencies: 1492
-- Data for Name: calls; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (1, '9209209202', '2008-12-15 00:00:00', 1, 0, 60);
INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (2, '9101112223', '2008-12-15 00:00:00', 2, 0, 61);
INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (3, '9209209202', '2008-12-15 00:00:00', 3, 0, 120);
INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (4, '9101112223', '2008-12-15 00:00:00', 4, 0, 1);
INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (5, '9209209202', '2008-12-15 00:00:00', 1, 1, 60);
INSERT INTO calls (id, calling_number, start_time, number_id, idx, duration) VALUES (6, '9031112223', '2008-12-15 00:00:00', 5, 0, 60);

