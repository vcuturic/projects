@isTest
class NewTest {
    // CRON_EXP: Seconds, Minutes, Hours, Day_of_month, Month Day_of_week Optional_year
    public static String CRON_EXP = '0 0 11 L 12 * *';
    /*PROBLEM: Treba da se proveri, 
    IF(zadnji dan u mesecu){
        Opali;
    }
    ELSE(zadnji dan u nedelji){
        
    }*/
    /////*********BITNO*********** */
    // String hour = String.valueOf(Datetime.now().hour());
    // String min = String.valueOf(Datetime.now().minute() + 1); 
    // String ss = String.valueOf(Datetime.now().second());

    // //parse to cron expression
    // String nextFireTime = ss + ' ' + min + ' ' + hour + ' * * ?';

    // SendTimesheets s = new SendTimesheets(); 
    // System.schedule('Job Started At ' + String.valueOf(Datetime.now()), nextFireTime, s);
    /////******************** */
    // try {
    //     List<Work_day_item__c> wdItems = [SELECT Day__c, Date__c, Project__c, MyTask__c, Hours__c FROM Work_day_item__c];
    //     delete wdItems;
    // } catch (System.DMLException e) {
    //     System.debug(e);
    // }
    

    // Auth.JWT jwt = new Auth.JWT();

        // // jwt.setSub('jwick3@vchco.com');
        // // jwt.setSub('jshep@vchco.com'); // Force - Free user
        // jwt.setSub('vcuturic@vchco.com'); // ADMIN
        
        // jwt.setAud('https://login.salesforce.com/');
        // jwt.setIss('3MVG9p1Q1BCe9GmAhdiYEexfKY15RrabsgdejAc387e7HdfZJYn037ZSFk5TtiWPG9nIxTgeJwRAhOwP3H36a');

        // // Map<String, String> claims = new Map<String, String>();
        // // claims.put('person_id', personID);
        // // jwt.setAdditionalClaims(claims);

        // // object that singns the JWT bearer token
        // Auth.JWS jws = new Auth.JWS(jwt, 'pInfo');
        // String token = jws.getCompactSerialization();
        
        // // set the token endpoint that the jwt bearer token is posted to
        // String tokenEndPoint = 'https://login.salesforce.com/services/oauth2/token';
        // // POST the JWT bearer token
        // Auth.JWTBearerTokenExchange bearer = new Auth.JWTBearerTokenExchange(tokenEndPoint, jws);
        
        // String aToken = bearer.getAccessToken();
        // HttpResponse response = bearer.getHttpResponse();

        // // myresponse = json.serializePretty(response.getBody());
        // // myresponse = jwt.toJSONString() + '\nTOKEN: ' + token;

        // System.debug('ACCESS TOKEN: ' + aToken);
        // Please add your logic according to requirement
    static testmethod void test() {
        Test.startTest();
        // Schedule the test job
        String jobId = System.schedule('ScheduledApexTest',
            CRON_EXP,
            new SendTimesheets());
        Test.stopTest();

        List<CronTrigger> cts = [SELECT Id, TimesTriggered, NextFireTime FROM CronTrigger WHERE Id = :jobId];
        System.debug('Next fire time ' + cts[0].NextFireTime);
    }
    @IsTest
    static void methodName(){
        
        Test.startTest();
            Person__c person = new Person__c(
                Name = 'Dummy',
                LastName__c = 'User',
                E_Mail__c = 'duser@vchco.com'
            );
            insert person;
        Test.stopTest();
        
    }
    
}
