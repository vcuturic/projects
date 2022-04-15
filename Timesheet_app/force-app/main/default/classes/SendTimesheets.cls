global class SendTimesheets Implements Schedulable {

    global void execute(SchedulableContext ctx) {
        // awesome code here
        sendmail();
    }
    global void finish(Database.BatchableContext BC)
    {
        // Get the ID of the AsyncApexJob representing this batch job from Database.BatchableContext.
        // Query the AsyncApexJob object to retrieve the current job's information.
        // AsyncApexJob a = [SELECT Id, Status, NumberOfErrors, JobItemsProcessed, TotalJobItems, CreatedBy.Email FROM AsyncApexJob WHERE Id = 
        // :BC.getJobId()];

        // //then use the active job id and abort it
        // system.abortJob(a.id);
    }
    public void sendmail()
    {
        List<Person__c> persons = [SELECT Name, Token__c FROM Person__c];
        Messaging.SingleEmailMessage email = new Messaging.SingleEmailMessage();
        //
        List<String> toadresses = new List<String>();
        toadresses.add('vikky15.99@gmail.com');
        String site = 'https://vchco-developer-edition.na163.force.com/?token=';
        for (Person__c p : persons) {   
            String random = String.valueOf(Integer.valueof((Math.random() * 1000))) + p.Id;
            Blob myBlob = Blob.valueOf(random);
            Blob md5hash = Crypto.generateDigest('MD5', myBlob);
            p.Token__c = EncodingUtil.convertToHex(md5hash);
            //
            email.setSubject('Token');
            email.setPlainTextBody('Your link: '+site+p.Token__c);
            email.setToAddresses(toadresses);
            Messaging.sendEmail(New Messaging.SingleEmailMessage[]{email});
        } 
        try {
            upsert persons;
        } catch (DmlException e) {
            System.debug('DML Exception ' + e.getMessage());
        }
        
    }
}
