import { Button, Card, Container, Divider, Typography } from '@mui/material'
import { NavLink } from 'react-router'
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';

export default function NotFound() {
    return (
        <Container component={Card} sx={{ p: 3 }}>
            <Typography variant="h5" gutterBottom>Page Not Found</Typography>
            <Divider />
            <Button variant="contained" component={NavLink} to="/" sx={{ mt: 2 }} startIcon={<ArrowBackIosIcon />}>
                Go Back
            </Button>
        </Container>
    )
}
