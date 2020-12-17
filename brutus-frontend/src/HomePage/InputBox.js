import React, {useState, useEffect} from 'react';
import 'typeface-roboto';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import { useCookies } from 'react-cookie';
import Button from '@material-ui/core/Button';

function rand() {
  return Math.round(Math.random() * 20) - 10;
}

function getModalStyle() {
  const top = 50 + rand();
  const left = 50 + rand();

  return {
    top: `${top}%`,
    left: `${left}%`,
    transform: `translate(-${top}%, -${left}%)`,
  };
}

const useStyles = makeStyles(theme => ({
  paper: {
    position: 'absolute',
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
}));

export default function InputBox(){

      const [cookies,setCookie] = useCookies(['isAccepted']);
       
      const classes = useStyles();
      // getModalStyle is not a pure function, we roll the style only on the first render
      const [modalStyle] = React.useState(getModalStyle);
      const [open, setOpen] = React.useState(false);
      const [isAccepted, setAccepted] = React.useState(false);

      const handleOpen = () => {
        setOpen(true);
      };
    
      const handleClose = () => {
        setOpen(false);
      };

      useEffect(() => {
        if(!cookies.isAccepted)       
         setOpen(true);  
         console.log(cookies.isAccepted)
      });

      function acceptFunction(){
        setAccepted(true)
        handleClose()
        onChange()
      }

      function onChange(){
        setCookie('isAccepted',true,{path:'/'})
      }

        return (
            <div>
              {handleOpen}
              <Modal
                aria-labelledby="simple-modal-title"
                aria-describedby="simple-modal-description"
                open={open}
                onClose={handleClose}
              >
                <div style={modalStyle} className={classes.paper}>
                  <h2 id="simple-modal-title">Komunikat o ciasteczkach</h2>
                  <p id="simple-modal-description">
                  <h6>Ta strona wykorzystuje pliki cookie.</h6>
                    <Button style={{borderRadius: 5, backgroundColor: '#4C00D9', color: '#FFFFFF',width: '50%', height: '5%', justify: 'center', align:'center', letterSpacing: 5, fontWeight: "bold", marginTop: 10, marginLeft: '25%'}} onClick={() =>acceptFunction()}>Akceptuje</Button>
                  </p>
                  <Modal />
                </div>
              </Modal>
            </div>
          );
}
