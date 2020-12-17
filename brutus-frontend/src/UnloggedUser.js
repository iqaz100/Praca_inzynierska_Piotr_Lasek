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
import InputBox from './HomePage/InputBox'

class App extends React.Component {
  state = {
    isLogin: false
  }
  render()
  {
    return (
      <>
      {!this.state.isLogin ? (
        <BrowserRouter>
          {/*
            * O ile w większości przypadków chcemy, żeby Route renderował nam zupełnie inną stronę
            * na podstawie jakieś ścieżki to może się okazać, że pewne elementy jak np. header, nawigacja czy stopka
            * są wspólne dla wszystkich podstron. Wtedy możemy wygodnie dodać te komponenty "obok" naszy routów.
            * W tym przypadku poniższy
            */}
          <Switch>
            <Route exact={true} path="/login" component={LoginPage} />
            <Route path="/*" component={LoginPage} />
          </Switch>
        </BrowserRouter>
      ) : (
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
            <Route exact={true} path="/home/teacher/grades" component={TeacherGradesPage} />
            <Route component={Page404} />
          </Switch>
        </BrowserRouter>
      )}
      </>
    );
  }
}

export default App;
