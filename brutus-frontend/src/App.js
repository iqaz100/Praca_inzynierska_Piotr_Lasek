import React from 'react';

import { BrowserRouter, Switch, Route } from 'react-router-dom';
import LoginPage from './LoginPage/LoginPage'
import HomePage from './HomePage/HomePage'
import GradesPage from './GradesPage/GradesPage'
import AbsencesPage from './AbsencesPage/AbsencesPage'
import BehaviourPage from './BehaviourPage/BehaviourPage'
import LessonsPage from './LessonsPage/LessonsPage'
import ProfilePage from './ProfilePage/ProfilePage'
import TeacherGradesPage from './TeacherGradesPage/TeacherGradesPage'
import Page404 from './Errors/404'
import NavBar from './NavBar'
import NavBarTeacher from './NavBarTeacher'
import InputBox from './HomePage/InputBox'
import { CookiesProvider } from 'react-cookie';


class App extends React.Component {
  state = {
    isLogin: false,
  }

  render()
  {
    return (
      
      <>
      <CookiesProvider>
      {JSON.parse(localStorage.getItem('user')).typeId == 1 &&  
        <BrowserRouter>
        {
          <NavBarTeacher></NavBarTeacher>
        }

        <InputBox></InputBox>
        <Switch>
          <Route exact={true} path="/home" component={HomePage} />
          <Route exact={true} path="/home/teacher/grades" component={TeacherGradesPage} />
          <Route exact={true} path="/home/profile" component={ProfilePage} />
          <Route component={Page404} />
        </Switch>
        </BrowserRouter>
      }

      {JSON.parse(localStorage.getItem('user')).typeId == 0 && 
        <BrowserRouter>
          {
            <NavBar></NavBar>
          }

          <InputBox></InputBox>
          <Switch>
            <Route exact={true} path="/home" component={HomePage} />
            <Route exact={true} path="/home/grades" component={GradesPage} />
            <Route exact={true} path="/home/absences" component={AbsencesPage} />
            <Route exact={true} path="/home/behaviour" component={BehaviourPage} />
            <Route exact={true} path="/home/lessons" component={LessonsPage} />
            <Route exact={true} path="/home/teacher" component={HomePage} />
            <Route exact={true} path="/home/profile" component={ProfilePage} />
            <Route component={Page404} />
          </Switch>
        </BrowserRouter>
      }

      {JSON.parse(localStorage.getItem('user')).typeId == 2 &&
         <BrowserRouter>
         {
           <NavBar></NavBar>
         }

         <InputBox></InputBox>
         <Switch>
           <Route exact={true} path="/home" component={HomePage} />
           <Route exact={true} path="/home/grades" component={GradesPage} />
           <Route exact={true} path="/home/absences" component={AbsencesPage} />
           <Route exact={true} path="/home/behaviour" component={BehaviourPage} />
           <Route exact={true} path="/home/lessons" component={LessonsPage} />
           <Route exact={true} path="/home/teacher" component={HomePage} />
           <Route exact={true} path="/home/profile" component={ProfilePage} />
           <Route component={Page404} />
         </Switch>
       </BrowserRouter>
      }

      </CookiesProvider>
      </>
      
    );
  }
}

export default App;
