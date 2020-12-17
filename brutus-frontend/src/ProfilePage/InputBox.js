import React from 'react';
import Grid from '@material-ui/core/Grid';
import 'typeface-roboto';
import color from '@material-ui/core/colors/deepOrange';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Box from '@material-ui/core/Box';
import { Label } from '@material-ui/icons';
import ConnectDB from '../ConnectDB';
import SnackbarContent from '@material-ui/core/SnackbarContent';

var styles = {
    loginToBrutus: {
    fontSize: 20,
    marginTop: 0,
    marginBottom: -155,
    paddingTop: 150,
    marginLeft: -200,
    fontFamily: "Helvetica",
    fontWeight: "Bold"
    }
}    

export default class InputBox extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            login:JSON.parse(window.localStorage.getItem('login')),
            oldPassword:"",
            newPassword:"",
        }
    }

    borderProperties = {
        bgcolor: color[0],
        borderColor: '#4C00D9',
        m: 20,
        border: 3,
        style: { width: '500px', height: '310px' },
      }; 

    changePassword(){
        this.handleOpen();
        ConnectDB.changePassword(this.state.login,this.state.oldPassword,this.state.newPassword)
        .then(res => {
            if(typeof res !== 'undefined'){
                console.log(res)
                this.setState({ error: false, information: true });
              }
              else {

                this.setState({ error: true, information: false });
                this.handleClose();
              }
        
        })
    }  

    handleOpen = () => this.setState({ active: true })
    handleClose = () => this.setState({ active: false })

    render() {
        const { active } = this.state
        let badData = this.state.error
        ?  <div><SnackbarContent  message ='Hasło zostało zmienione' /></div>
        : null

        let goodData = this.state.information
        ?  <div><SnackbarContent  message ='Nieprawidłowe hasło' /></div>
        : null

        {   
            return (
                <>
                <Grid container justify="center" alignItems="center">
                    <Box display="flex" justifyConent="center">
                        <Box borderRadius="borderRadius" {...this.borderProperties}>
                            <TextField onChange={(e) => {this.setState({oldPassword:e.target.value})}} id="old-psw" label="Stare hasło" variant="outlined" style={{width:400,marginTop:30,marginLeft:44}}/>
                            <TextField onChange={(e) => {this.setState({newPassword:e.target.value})}} id="new-psw" label="Nowe hasło" variant="outlined" style={{width:400,marginTop:30,marginLeft:44}}/>
                            <Button onClick={() => this.changePassword()} variant="contained" color="primary" style={{width:400,marginTop:30,marginLeft:44}}>Zmień hasło</Button>
                        </Box>
                    </Box>

                </Grid>
                {badData}
                </>
            );
    }
}
}