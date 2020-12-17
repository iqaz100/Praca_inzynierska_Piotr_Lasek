import {handleResponse} from './utils.js'

class ConnectDB{
  
    //----------------------------GRADES-------------------------------

    static async getStudentGrades(id){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Grades/GetStudentGrades?studentId='+id, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async getSubjectGrades(id){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Grades/GetSubjectGrades?subjectId='+id, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async addGrade(gradeScale, gradeType, studentId, gradedefId, teacherId, subjectId){
        const headers = new Headers([['Content-Type', 'application/json']]);
        let object = {
            gradeScale, 
            gradeType, 
            studentId, 
            gradedefId,
            teacherId,
            subjectId}
  
          try {
            const res = await fetch('http://localhost:57855/api/Grades/AddGrade', {
                method: 'POST',
                headers: headers,
                body: JSON.stringify(object),
                contentType:'application/json; charset=UTF-8'
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async deleteGrade(id){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Grades/DeleteGrade?gradeId='+id, {
                method: 'DELETE',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async getClassGrades(classId,subjectId){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Grades/GetClassGrades?classId=' + classId + '&subjectId='+subjectId, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async getAverageGrade(studentId,subjectId){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Grades/GetAverageGrade?studentId='+ studentId +'&subjectId=' + subjectId, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }




    //----------------------------ABSENCES------------------------------//

    static async getAllStudentAbsences(id){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Absences/GetAllStudentAbsences?idStudent='+id, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async excuseAbsence(id){
        const headers = new Headers([['Content-Type', 'application/json'],['Access-Control-Allow-Origin', '*']]);
        try {
            const res = await fetch('http://localhost:57855/api/Absences/ExcuseAbsence?idAbsence='+id, {
                method: 'PUT',
                headers: headers,
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    //--------------------------------BEHAVIOUR----------------------------//

    static async getStudentBehavior(id){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Behavior/GetStudentBehavior?idStudent='+id, {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    //-----------------------------SUBJECT-----------------------------//

    static async getAllCourses(){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Subject/GetAllCourses', {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    //-----------------------------CLASS-------------------------------//

    static async getAllClasses(){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Class/GetAllClasses', {
                method: 'GET',
                headers: headers
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    //------------------------LOGIN-----------------------------------//

    static async authUser(login,password){
        const headers = new Headers([['Accept', 'application/json']]);
        try {
            const res = await fetch('http://localhost:57855/api/Login/AuthUser?login=' + login + '&password='+ password, {
                method: 'GET',
                headers: headers
            });
        
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }

    static async changePassword(login,oldPassword,newPassword){
        const headers = new Headers([['Content-Type', 'application/json'],['Access-Control-Allow-Origin', '*']]);
        try {
            const res = await fetch('http://localhost:57855/api/Login/ChangePassword?login='+login+'&oldPassword='+oldPassword+'&newPassword='+newPassword, {
                method: 'PUT',
                headers: headers,
            });
            const res_1 = await res.json();
            return res_1;
        }
        catch (error) {
            console.error('Error:', error);
        }
    }




    

}
export default ConnectDB;