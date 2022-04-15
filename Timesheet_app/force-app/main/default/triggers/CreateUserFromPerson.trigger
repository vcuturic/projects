trigger CreateUserFromPerson on Person__c (after insert, after update) {

    // List<User> users = new List<User>();
    // for (Person__c person : Trigger.new) {
    //     User user = new User(
    //         FirstName= person.Name,
    //         LastName = person.LastName__c,
    //         Alias = person.Name.substring(0,1) + person.LastName__c,
    //         Email = person.E_Mail__c,
    //         Username = person.Name.substring(0,1) + person.LastName__c + person.personID__c + '@vchco.com',
    //         ProfileId = '00e5f000002f1zXAAQ',
    //         TimeZoneSidKey = 'GMT',
    //         LanguageLocaleKey = 'en_US',
    //         EmailEncodingKey = 'UTF-8',
    //         LocaleSidKey = 'sr_RS',
    //         personID__c = integer.valueof(person.personID__c) 
    //     );
    //     users.add(user);
    // }
    // try { insert users; }
    // catch(DmlException e){ System.debug('DML Exception ' + e.getMessage()); }

    // Profile profId = [select Id from Profile where name=:'Force.com - Free User' limit 1];
    // System.debug('PROFILE ID' + profId);

    /** Treba promeniti, da kad se insertuje user da se napravi User */
}