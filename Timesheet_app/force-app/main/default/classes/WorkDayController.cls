/*
WorkDayController wdc = new WorkDayController();
*/
public with sharing class WorkDayController {

    public Work_day_item__c wdItem {get; set;}
    public String accessToken {get; set;}
    public String fName {get; set;}
    public String myresponse {get; set;}
    public Boolean successfullAddedItem {get; set;}
    //
    public Person__c thisPerson {get; set;}
    public String projectID {get; set;} // from selected List
    public String taskID {get; set;}
    public List<Work_day_item__c> currentWdItems{get; set;} // List of wdItems the user added for this week
    public Date currentDate {get; set;}

    public List<Work_day_item__c> getcurrentWdItemsByDate(){
        List<Work_day_item__c> cwditemsbydate = new List<Work_day_item__c>();
        for (Work_day_item__c wditm : currentWdItems) {
            if(wditm.Date__c == currentDate)
                cwditemsbydate.add(wditm);
        }
        return cwditemsbydate;
    }
    
    public void dummyFunc(){
        // Used to pass variables from JS
    }
    public void init(){
        
        // anti-null
        projectID = '0';
        taskID = '0';
        currentWdItems = new List<Work_day_item__c>();
        currentDate = System.today();
        // Getting the user from token
        String token;
        try {
            PageReference pageRef = ApexPages.currentPage();
            token = pageRef.getParameters().get('token');
        } catch (Exception e) {
            ApexPages.addMessages(e);
        }
        thisPerson = [SELECT Name, personID__c FROM Person__c WHERE Token__c =:token LIMIT 1];
        // thisPerson = [SELECT Name, personID__c FROM Person__c WHERE personID__c =: '3' LIMIT 1];
    }
    public map<String,String> getParams(){
        PageReference pageRef = ApexPages.currentPage();
        Map<String,String> params_map = new map <String,String>(pageRef.getParameters());
        return params_map;
    }
    public WorkDayController() {

        Id id = ApexPages.currentPage().getParameters().get('id');
        
        wdItem = (id == null ) ? new Work_day_item__c() : [SELECT Day__c, Date__c, Project__c, MyTask__c, Hours__c FROM Work_day_item__c WHERE Id=:id ];
    }

    /* ReWorked!*/
    
    public List<SelectOption> getProjects() {
        List<SelectOption> options = new List<SelectOption>();
        
        // Get the projecets associated with the user
        List<PersonProjects__c> personProjects = [SELECT projectID__c FROM PersonProjects__c WHERE personID__c = : Decimal.valueOf(thisPerson.personID__c) ];
        // Convert project IDs to List of strings
        List<String> personProjectsIds = new List<String>();
        for (PersonProjects__c var : personProjects) {
            personProjectsIds.add(String.valueOf(var.projectID__c));
        }
        // Get projects Names the user is working on
        List<Project__c> projects = [SELECT Name, projectID__c FROM Project__c WHERE projectId__c IN: personProjectsIds ];
        if(!projects.isEmpty()){
            for (Project__c p : projects) {
                options.add(new SelectOption(p.projectID__c, p.Name)); // get projID as Value
            }
        }
        else 
            options.add(new SelectOption('None', 'None')); 
        return options;
    }
    public List<SelectOption> getMyTasks() {
        List<SelectOption> options = new List<SelectOption>();
        
        List<String> associatedTasksIDs = new List<String>();
        // projectID from selectedProject List
        // Check for error values
        if(projectID == '0' || projectID == '' || projectID == 'None')
            options.add(new SelectOption('None', 'None'));
        else{
            // Get the Task associated with the selected Project
            List<TasksProjects__c> associatedTasks = [SELECT taskID__c, projectID__c FROM TasksProjects__c WHERE projectID__c =: Decimal.valueOf(projectID) ];
            // Convert associatedTasks  to List of strings
            for (TasksProjects__c var : associatedTasks) {
                associatedTasksIDs.add(String.valueOf(var.taskID__c));
            }
        }
        // Get Task Names 
        List<MyTask__c> tasks = [SELECT Name, taskID__c FROM MyTask__c WHERE taskID__c IN: associatedTasksIDs ];

        for (MyTask__c t : tasks) {
            options.add(new SelectOption(t.taskID__c, t.Name));
        }
        return options;
    }

    public List<Day__c> getWorkDays(){
        Datetime today = System.today();
        today.addHours(0); // needed for the Day Name
        List<Day__c> days = new List<Day__c>();
        for (Integer i = 0; i < 5; i++) {
            Day__c day = new Day__c();
            day.DayNum__c = today.day();
            day.Name = today.format('EEEE');
            day.DayInWeek__c = i;
            day.DayOfMonth__c = today.month();
            day.DateStr__c = today.format('dd.MM.yyyy.');
            days.add(day);
            today+=1;
        }
        return days;
    }
    
    /** END of ReWorked */

    public List<Work_day_item__c> getWorkDayItems(){
        List<Work_day_item__c> wdItems = [SELECT Day__c, Date__c, Project__c, MyTask__c, Hours__c FROM Work_day_item__c ORDER BY Date__c ASC ];
        return wdItems;
    }
    public PageReference save(){
        try {
            Project__c proj = [SELECT Name, projectID__c FROM Project__c WHERE projectID__c =: projectID LIMIT 1];
            wdItem.Project__c = proj.Id;
            MyTask__c tsk = [SELECT Name, taskID__c FROM MyTask__c WHERE taskID__c =: taskID LIMIT 1];
            wdItem.MyTask__c = tsk.Id;
            Work_day_item__c currentWditem = new Work_day_item__c(
                Date__c = wdItem.Date__c,
                Day__c = wdItem.Day__c,
                Hours__c = wdItem.Hours__c,
                Project__c = wdItem.Project__c,
                MyTask__c = wdItem.MyTask__c
            );
            currentWdItems.add(currentWditem);
            upsert(wdItem);
            wdItem.Id = null; // reset the item
            successfullAddedItem = true;
        } catch(System.DMLException e) {
            ApexPages.addMessages(e);
            return null;
        }
        return null;
    }
    public PageReference test(){
        return null;
    }
    // @RemoteAction
    // public static void setWorkDay(Work_day_item__c wdi){
    //     WorkDayController.wdItem.Day__c = wdi.Day__c;
    //     WorkDayController.wdItem.Date__c = wdi.Date__c;
    // }

    // public Boolean section1 {get; set;}
    // public void updateData() {
    //     if(projects == 'Timesheet') {
    //             this.section1 = true;
    //     }
    //     else {
    //         this.section1 = false;
    //     }
    // }
}

