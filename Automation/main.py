from playwright.sync_api import sync_playwright
import time
import psycopg2

database_info = {
    "host": "localhost",
    "database": "rede-social",
    "user": "postgres",
    "password": "12345678"
}


url_default = 'https://globo.gupy.io'

def getJob(playwright, url):
    try:
        #criar uma nova guiae
        page = playwright.new_page()
        page.goto(url_default + url)
        
        #acessar a pagina
        page.query_selector('//*[@id="radix-0"]/div[2]/button').click()
        #Pegar os dados necessarios
        job.title = page.query_selector('//*[@id="h1"]').inner_text()
        job.date_publish = page.query_selector('//*[@id="main"]/div/div[1]/div[2]/div[1]/p[1]').inner_text()
        job.deadline_submit = page.query_selector('//*[@id="main"]/div/div[1]/div[2]/div[1]/p[1]').inner_text()
        job.type_job = page.query_selector('//*[@id="main"]/div/div[1]/div[2]/div[3]/p[2]/span').inner_text()
        job.description_text = page.query_selector('//*[@id="main"]/div/section[1]').inner_text()
        job.description_html = page.query_selector('//*[@id="main"]/div/section[1]').inner_html()
        job.url = url_default + url
        
        #inserir na base
        insertJob(job)
        page.close()
    except Exception as err:
        print("Erro :", err)

def insertJob(job):
        connection = psycopg2.connect(**database_info)
        with connection.cursor() as cursor:
            sql = f'''INSERT INTO jobs (title, date_publish, deadline_submit, type_job, description_text, description_html, url, etl, no_sql)
        VALUES ('{job.title}', '{job.date_publish}', '{job.deadline_submit}', '{job.type_job}', '{job.description_text}', '{job.description_html}', '{job.url}', false, false);'''
            cursor.execute(sql)
            connection.commit()
    
        

if __name__ == "__main__":
    with sync_playwright() as p:
        print('-------------------------Inicio Captura---------------------------')
        navegador = p.chromium.launch(headless=False)
        page = navegador.new_page()
        
        #Acessar a pagina, aceitando os cookies e aumentando o range de vagas
        page.goto("https://globo.gupy.io/#xd_co_f=YmJkN2RjM2UtMGNmYS00ODViLWIwYWItNDU0MTY5ZmQ5ZjFj~")
        page.query_selector('//*[@id="radix-0"]/div[2]/button').click()
        page.query_selector('//*[@id="job-listing"]/div[3]/div[3]/div/div/div/div/div[2]/div').click()
        page.query_selector('//*[@id="react-select-5-option-4"]').click()
        
        #pegar lista de vagas
        list_jobs = page.query_selector_all('//*[@id="job-listing"]/ul/li')
        for job in list_jobs:
            link_job = job.query_selector('a')
            if link_job:
                link = link_job.get_attribute('href')
                if(link):
                    getJob(navegador, link)
            print('Vaga:')
            print(job.inner_text())

        print('-------------------Final Captura---------------------')
        time.sleep(5)


    
