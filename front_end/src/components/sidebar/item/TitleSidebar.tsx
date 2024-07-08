import Typography from '@mui/material/Typography';
import React from 'react';

const TitleSidebar = ({ children, content }: { children: React.ReactNode; content: React.ReactNode }) => {
    return (
        <Typography
            sx={{
                fontSize: '13px',
                fontWeight: '300',
                paddingBottom: '16px',
                marginBottom: '20px',
                position: 'relative',
                display: 'flex',
                alignItems: 'center',
                '&::before': {
                    content: '""',
                    position: 'absolute',
                    left: '0',
                    bottom: '0',
                    width: '100%',
                    height: '1px',
                    backgroundColor: '#696969',
                    opacity: 0.2,
                },
                '&::after': {
                    content: '""',
                    position: 'absolute',
                    left: '0',
                    bottom: '0',
                    width: '30px',
                    height: '3px',
                    backgroundColor: '#b5e745',
                },
            }}
        >
            {content}
            {children}
        </Typography>
    );
};

export default TitleSidebar;
