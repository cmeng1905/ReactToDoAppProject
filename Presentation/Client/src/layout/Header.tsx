import { AppBar, Box, Button, Container, Divider, Drawer, IconButton, Link, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Toolbar, Typography } from "@mui/material";
import FormatListBulletedIcon from '@mui/icons-material/FormatListBulleted';
import { useState } from "react";
import InboxIcon from '@mui/icons-material/Inbox';
import MailIcon from '@mui/icons-material/Mail';
export default function Header() {
    const [open, setOpen] = useState(false);

    const toggleDrawer = (newOpen: boolean | ((prevState: boolean) => boolean)) => () => {
        setOpen(newOpen);
    };

    const DrawerList = (
        <Box sx={{ width: 250 }} role="presentation" onClick={toggleDrawer(false)}>
            <List>
                {['Inbox', 'Starred', 'Send email', 'Drafts'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>
                                {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
                            </ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
            <Divider />
            <List>
                {['All mail', 'Trash', 'Spam'].map((text, index) => (
                    <ListItem key={text} disablePadding>
                        <ListItemButton>
                            <ListItemIcon>
                                {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
                            </ListItemIcon>
                            <ListItemText primary={text} />
                        </ListItemButton>
                    </ListItem>
                ))}
            </List>
        </Box>
    );
    return (
        <AppBar position="static" sx={{ backgroundColor: '#082666' }}>
            <Toolbar sx={{ display: 'flex', justifyContent: "space-between" }}>
                <Box sx={{ display: 'flex', alignItems: 'center' }}>
                    <IconButton
                        size="large"
                        edge="start"
                        color="inherit"
                        aria-label="menu"
                        sx={{ mr: 2 }} onClick={toggleDrawer(true)}>
                        <FormatListBulletedIcon />
                    </IconButton>
                    <Link href="/" sx={{ color: 'inherit', textDecoration: 'none' }}>
                        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                            ToDo App
                        </Typography>
                    </Link>
                </Box>
                <Button color="inherit">Login</Button>
            </Toolbar>
            <Drawer open={open} onClose={toggleDrawer(false)}>
                {DrawerList}
            </Drawer>
        </AppBar>
    )
}
