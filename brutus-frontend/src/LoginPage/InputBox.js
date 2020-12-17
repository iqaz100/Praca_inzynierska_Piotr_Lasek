import React from 'react';
import Grid from '@material-ui/core/Grid';
import 'typeface-roboto';
import Box from '@material-ui/core/Box';
import color from '@material-ui/core/colors/deepOrange';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import ConnectDB from "../ConnectDB";
import SnackbarContent from '@material-ui/core/SnackbarContent';

export default class InputBox extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            login:"",
            password:"",
            pesel:"",
            loading:false
        };
    }

    borderProperties = {
        bgcolor: color[0],
        borderColor: '#4C00D9',
        m: 20,
        border: 3,
        style: { width: '500px', height: '310px' },
      };

      
    
    LoginUser(){
        if(this.checkFields()){
            this.handleOpen();
            ConnectDB.authUser(this.state.login, this.state.password)
            .then(res => {        
              if(typeof res !== 'undefined'){
                localStorage.setItem('user', JSON.stringify(res));
                localStorage.setItem('login',JSON.stringify(this.state.login));
                console.log("item" + localStorage.getItem('user'))
                window.location.reload(true)
              }
              else {

                this.setState({ error: true, warning: false });
                this.handleClose();
              }
            })
      
          } else {
            this.setState({ error: false, warning: true });
          }
    }

    checkFields(){
        if(
          this.state.email !== "" &&  
          this.state.password !== "")
        return true
        else return false
    }  
    
    handleOpen = () => this.setState({ active: true })
    handleClose = () => this.setState({ active: false })

    render() {
        const { active } = this.state
        let badData = this.state.error
        ?  <div><SnackbarContent  message ='Nieprawidłowe dane logowania' /></div>
        : null

        let nullData = this.state.warning
        ? <div><SnackbarContent message = 'Musisz wypełnić wszystkie pola'  /></div>
        : null

        {   
            
            return (
                <>
                
                <Grid container justify="center" alignItems="center">
                    <Box display="flex" justifyContent="center" align="center">
                        <Box borderRadius="borderRadius"  {...this.borderProperties} >
                        <TextField
                            id="filled-email-input"
                            label="Login"
                            type="login"
                            name="email"
                            autoComplete="login"
                            variant="filled"
                            style={{width: 400, marginTop: 70}}
                            onChange={(e) => {this.setState({login:e.target.value})}}
                            onKeyPress={(e) => {if (e.key === 'Enter') {e.preventDefault(); this.LoginUser();}}}
                        />
                        <TextField
                            id="filled-password-input"
                            label="Password"
                            type="password"
                            name="password"
                            autoComplete="password"
                            variant="filled"
                            style={{width: 400, marginTop: 40}}
                            onChange={(e) => {this.setState({password:e.target.value})}}
                            onKeyPress={(e) => {if (e.key === 'Enter') {e.preventDefault(); this.LoginUser();}}}
                        />
                        
                            <Button variant="contained" style={{borderRadius: 5, backgroundColor: '#4C00D9', color: '#FFFFFF', width: 280, height: 70, justify: 'center', letterSpacing: 5, fontWeight: "bold", marginTop: 50,}} onClick={() => this.LoginUser()} >
                                Zaloguj
                               
                            </Button>
                        </Box>
                    </Box>
                </Grid>
                {badData}
                {nullData}
                </>
            );
          }
    }
}