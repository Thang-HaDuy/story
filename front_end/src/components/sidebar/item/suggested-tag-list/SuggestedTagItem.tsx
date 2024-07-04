import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Link from 'next/link';

const SuggestedTagItem = ({ tag }: { tag: string }) => {
    return (
        <Box
            component={Link}
            href="/login"
            sx={{ textDecoration: 'none', display: 'inline-block', margin: '1px 10px' }}
        >
            <Typography
                sx={{
                    padding: '3px 7px',
                    borderRadius: '3px',
                    color: '#fff',
                    backgroundColor: 'rgba(0,0,0,.26)',
                    fontSize: '13px',
                    fontWeight: '300',
                    borderLeft: '5px solid #c33838',
                    '&:hover': { color: '#7d7d7d' },
                }}
            >
                {tag}
            </Typography>
        </Box>
    );
};

export default SuggestedTagItem;
