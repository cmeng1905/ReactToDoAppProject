import { Card, Container, Divider, Grid, Stack, Typography } from "@mui/material";
import { useLocation } from "react-router";
import DangerousIcon from '@mui/icons-material/Dangerous';
export default function ServerError() {
    const { state } = useLocation();
    console.log(state)
    return (
        <Container component={Card} sx={{ p: 3 }}>
            {
                state?.error ? (
                    <>
                        <Typography variant="h3" gutterBottom>{state.error.title} - {state.status}</Typography>
                        <Divider />
                        <Typography variant="body2">{state.error.detail || "Unknown Error"}</Typography>
                    </>
                ) : (
                    <Grid container alignItems="center">
                        <Grid size={1}>
                            <DangerousIcon fontSize="large" color="error" />
                        </Grid>
                        <Grid>
                            <Typography variant="h4">Server Error</Typography>
                            <Typography variant="body2">An unexpected error has occurred.</Typography>
                        </Grid>
                    </Grid>
                )
            }
        </Container >
    )
}
