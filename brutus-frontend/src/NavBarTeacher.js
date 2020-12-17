import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import Badge from '@material-ui/core/Badge';
import AccountCircle from '@material-ui/icons/AccountCircle';
import MailIcon from '@material-ui/icons/Mail';
import NotificationsIcon from '@material-ui/icons/Notifications';
import Icon from '@material-ui/core/Icon';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import Tab from '@material-ui/core/Tab';
import Tabs from '@material-ui/core/Tabs';
import { useHistory } from "react-router-dom";
import MenuItem from '@material-ui/core/MenuItem';
import Menu from '@material-ui/core/Menu';

const useStyles = makeStyles(theme => ({
    grow: {
        flexGrow: 1,
    },
    title: {
        fontWeight: "bold",
        borderRight: '0.1em solid white',
        padding: '10px',
        position: 'relative',
    },
    divider: {
        flexGrow: 1,
        borderRight: '0.1em solid white'
    }
}));

const theme = createMuiTheme({
    palette: {
        primary: {
            main: '#4C00D9'
        }
    }
},
)

var loggedUserFirstName = ""
var loggedUserLastName = ""

function setNames(){
    var nameAndSurname
    if(localStorage.getItem('user'))
    {
        loggedUserFirstName = JSON.parse(window.localStorage.getItem('user')).firstName;
        loggedUserLastName = JSON.parse(window.localStorage.getItem('user')).lastName;
    }
    nameAndSurname = loggedUserFirstName + " " + loggedUserLastName
    return nameAndSurname;
}


function logout()
{
    localStorage.removeItem('user')
    window.location.reload(true)
}
export default function PrimarySearchAppBar(props) {
    const classes = useStyles();
    const [value, setValue] = React.useState(2);
    const [anchorEl,setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    let history = useHistory();
    const handleChange = (event, newValue) => {
        switch (newValue) {
            case 0:
                history.push("/home/teacher/grades")
                break;
            case 2:
                history.push("/home/profile")
                break;
            case 3:
                history.push("/home")
                break;
            default:
                break;
        }
        setValue(newValue);
      };
      const handleMenu = (event) => {
        setAnchorEl(event.currentTarget);
      };
    
      const handleClose = () => {
        setAnchorEl(null);
      };

      const handleProfileOpen = () =>{
          history.push("/home/profile")
        };
     
    const homePageButton = () => {
        setValue(0);
        history.push("/home/teacher/grades")
    };

      
    return (
        <MuiThemeProvider theme={theme}>
            <div className={classes.grow}>
                <AppBar position="static" color="primary">
                    <Toolbar>
                        <IconButton 
                            value={value} 
                            onClick={() => homePageButton()}
                            onChange={handleChange}
                            edge="start"
                            className={classes.menuButton}
                            color="inherit"
                            aria-label="menu">
                            <Icon style={{ fontSize: 50 }}>schoolicon</Icon>
                        </IconButton>
                        <Typography variant="h5" className={classes.title}>
                            Brutus
                        </Typography>
                        <Typography variant="h5" className={classes.divider}>
                        </Typography>
                        <Tabs value={value} onChange={handleChange} aria-label="simple tabs example">
                            <Tab label="OCENY" onClick={() => setValue(0)}/> 
                        </Tabs>
                        <Typography variant="h5" className={classes.grow}>
                        </Typography>
                        <label>{setNames()}</label>
                        <IconButton
                            edge="end"
                            aria-label="account of current user"
                            aria-haspopup="true"
                            color="inherit"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            //onClick={() => logout()}
                            onClick={handleMenu}
                        >
                            <AccountCircle />
                            </IconButton>
                            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={open}
                onClose={handleClose}
              >
                <MenuItem onClick={handleProfileOpen}>Moje konto</MenuItem>
                <MenuItem onClick={()=> logout()}>Wyloguj</MenuItem>
              </Menu>
                    </Toolbar>
                </AppBar>
            </div>
        </MuiThemeProvider>
    );
}